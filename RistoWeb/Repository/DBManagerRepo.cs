using RistoWeb.Context;
using RistoWeb.Entity;
using RistoWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RistoWeb.Repository
{
    public class DBManagerRepo
    {
        private RistoWebDBContext DBContext;
        private static Guid userID;
        public DBManagerRepo(RistoWebDBContext DBContext)
        {
            this.DBContext = DBContext;
        }

        /* START USER */

        // return TRUE if user is logged
        public bool IsUserLogged()
        {
            User user = DBContext.Users.Where(x => x.UserID.Equals(userID)).FirstOrDefault();
            if (user != null)
            {
                bool isLogged = user.UserIn;
                return isLogged;
            }
            return false;
        }

        // return the user's name (currently logged)
        public string GetUserName()
        {
            User user = DBContext.Users.Where(x => x.UserID.Equals(userID)).FirstOrDefault();
            string name = user.Firstname;
            return name;
        }

        // return TRUE if the logged user has a reservation
        public bool IsUserReserved()
        {
            List<Reservation> userReservations = DBContext.Reservations.Where(x => x.UserID.Equals(userID)).ToList();
            if (userReservations.Count > 0)
                return true;
            else
                return false;
        }

        // return TRUE if the authentication was succesfull
        public bool SignIn(string email, string password)
        {
            User user = DBContext.Users.Where(x => x.Email.Equals(email)).FirstOrDefault();
            if (user != null && user.Password == password)
            {
                userID = user.UserID;
                user.UserIn = true;
                DBContext.Users.Update(user);
                DBContext.SaveChanges();
                return true;
            }
            else
                return false;
        }
        // return TRUE if the registration was succesfull
        public bool Register(User user)
        {
            User newUser = DBContext.Users.Where(x => x.Email.Equals(user.Email)).FirstOrDefault();
            if (newUser == null)
            {
                try
                {
                    DBContext.Users.Add(user);
                    DBContext.SaveChanges();
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
            else
                return false;
        }
        public void LogOut()
        {
            User user = DBContext.Users.Where(x => x.UserID.Equals(userID)).FirstOrDefault();
            user.UserIn = false;
            DBContext.Users.Update(user);
            DBContext.SaveChanges();
        }
       
        /* END USER */

        /* START MENU' */

        // return all the courses present in the server 
        public List<Course> GetAllCourses()
        {
            List<Course> courses = DBContext.Courses.ToList();
            return courses;
        }
        // return a daily random menù
        public MenuModel GetDailyMenu()
        {
            Random r = new Random();
            MenuModel menuModel = new MenuModel();
            List<Course> dailyMenu = new List<Course>();
            List<Course> mainCourse = DBContext.Courses.Where(x => x.C_Type.Equals(1)).ToList();
            List<Course> secondCourse = DBContext.Courses.Where(x => x.C_Type.Equals(2)).ToList();
            List<Course> sideCourse = DBContext.Courses.Where(x => x.C_Type.Equals(3)).ToList();
            List<Course> dessertCourse = DBContext.Courses.Where(x => x.C_Type.Equals(4)).ToList();
            dailyMenu.Add(mainCourse[r.Next(0, mainCourse.Count())]);
            dailyMenu.Add(secondCourse[r.Next(0, secondCourse.Count())]);
            dailyMenu.Add(sideCourse[r.Next(0, sideCourse.Count())]);
            dailyMenu.Add(dessertCourse[r.Next(0, dessertCourse.Count())]);
            menuModel.menu = dailyMenu;
            return menuModel;
        }
        /* END MENU' */


        /* START RESERVATION */
        public ReservationModel Reserve(DateTime data, int seats, bool lunch, bool dinner)
        {
            Reservation reservation = new Reservation()
            {
                DateRes = data,
                Seats = seats,
                UserID = userID,
                Lunch = lunch,
                Dinner = dinner
            };
            ReservationModel reservationModel = new ReservationModel()
            {
                reservation = reservation
            };
            if (seats > 0 && (lunch || dinner))
            {
                int availableSeats = reservationModel.maxSeats - GetReserveredSeats(reservation);
                if (!CheckForReservation(reservation))
                {
                    // success registration
                    if (availableSeats >= reservationModel.reservation.Seats)
                    {
                        reservationModel.seatsFull = false;
                        reservationModel.isAlreadyReserved = false;
                        reservationModel.successReservation = true;
                        DBContext.Reservations.Add(reservation);
                        DBContext.SaveChanges();
                        return reservationModel;
                    }
                    // full seats
                    else
                    {
                        reservationModel.seatsFull = true;
                        reservationModel.isAlreadyReserved = false;
                        reservationModel.successReservation = false;
                        return reservationModel;
                    }
                }
                // already registered
                else
                {
                    reservationModel.seatsFull = false;
                    reservationModel.isAlreadyReserved = true;
                    reservationModel.successReservation = false;
                    return reservationModel;
                }
            }
            // normal
            else
            {
                reservationModel.seatsFull = false;
                reservationModel.isAlreadyReserved = false;
                reservationModel.successReservation = false;
                return reservationModel;
            }
        }

        // cancel reservation
        public void CancelReservation(Guid resId)
        {
            // context.Remove(context.Authors.Single(a => a.AuthorId == 1))
            Reservation reservation = DBContext.Reservations.Single(x => x.ResID.Equals(resId));
            DBContext.Remove(reservation);
            DBContext.SaveChanges();
        }

        // return the user's reservations
        public List<Reservation> GetUserReservation()
        {
            List<Reservation> userReservations = DBContext.Reservations.Where(x => x.UserID.Equals(userID)).ToList();
            return userReservations;
        }

        // return how many seats are reserved
        public int GetReserveredSeats(Reservation reservation)
        {
            int seats = 0;
            List<Reservation> bookingTime = GetBookingTime(reservation);
            foreach (Reservation newReservation in bookingTime)
                seats += newReservation.Seats;
            return seats;
        }

        // return TRUE if a reservation already exist
        public bool CheckForReservation(Reservation reservation)
        {
            List<Reservation> bookingTime = GetBookingTime(reservation);
            // check if already userID exist in bookingTime (lunch or dinner reservation)
            foreach (Reservation oldReservation in bookingTime)
            {
                if (oldReservation.UserID == userID)
                    return true;
            }
            return false;
        }

        // return a List<Reservation> which contains the data reservation for lunch or dinner
        public List<Reservation> GetBookingTime(Reservation reservation)
        {
            List<Reservation> bookingTime = new List<Reservation>();
            // create a list of all reservation for inserted data
            List<Reservation> dataReservation = DBContext.Reservations.Where(x => x.DateRes.Equals(reservation.DateRes)).ToList();
            // split dataReservation for lunch or dinner reservation (bookingTime)
            foreach (Reservation oldReservation in dataReservation)
            {
                if (reservation.Lunch)
                {
                    if (oldReservation.Lunch)
                        bookingTime.Add(oldReservation);
                }
                else if (reservation.Dinner)
                {
                    if (oldReservation.Dinner)
                        bookingTime.Add(oldReservation);
                }
            }
            return bookingTime;
        }

        /* END RESERVATION */


        /* DEVELOPE HELPER */
        // return all user saved in the server
        public List<User> GetAllUsers()
        {
            List<User> users = DBContext.Users.ToList();
            return users;
        }
    }
}
