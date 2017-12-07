//
// BusinessTier:  business logic, acting as interface between UI and data store.
//

using System;
using System.Collections.Generic;
using System.Data;


namespace BusinessTier
{

  //
  // Business:
  //
  public class Business
  {
    //
    // Fields:
    //
    private string _DBFile;
    private DataAccessTier.Data dataTier;


    //
    // Constructor:
    //
    public Business(string DatabaseFilename)
    {
      _DBFile = DatabaseFilename;

      dataTier = new DataAccessTier.Data(DatabaseFilename);
    }


    //
    // TestConnection:
    //
    // Returns true if we can establish a connection to the database, false if not.
    //
    public bool TestConnection()
    {
      return dataTier.TestConnection();
    }


    //
    // GetUser:
    //
    // Retrieves User object based on USER ID; returns null if user is not
    // found.
    //
    // NOTE: if the user exists in the Users table, then a meaningful name and 
    // occupation are returned in the User object.  If the user does not exist 
    // in the Users table, then the user id has to be looked up in the Reviews 
    // table to see if he/she has submitted 1 or more reviews as an "anonymous"
    // user.  If the id is found in the Reviews table, then the user is an
    // "anonymous" user, so a User object with name = "<UserID>" and no occupation
    // ("") is returned.  In other words, name = the user’s id surrounded by < >.
    //
    public User GetUser(int UserID)
    {
            //Format string to search for ID
            string sql = string.Format(@"Select * From Users Where UserID = '{0}';", UserID);
            DataSet result = dataTier.ExecuteNonScalarQuery(sql);

            if (result.Tables[0].Rows.Count == 0) //checks if result is empty, meaning user is not in Users table
            {
                //create second string to search for the id in the reviews table
                string sql2 = string.Format(@"Select UserID From Reviews Where UserID = '{0}';", UserID);
                DataSet result2 = dataTier.ExecuteNonScalarQuery(sql2);

                //if-else to check if id is in the Reviews table, if not return null
                if(result2.Tables[0].Rows.Count == 0)
                {
                    return null;
                }
                else //create the user based on result from thre Reviews table
                {
                    DataRowCollection rows = result2.Tables["Table"].Rows;
                    DataRow row = rows[0];


                    string nUserID = Convert.ToString(row["UserID"]);
                    string UnkownName = string.Format(@"<{0}>", nUserID);
                    User u2 = new BusinessTier.User(Convert.ToInt32(row["UserID"]), UnkownName, "");

                    return u2;
                }
            }
            else //create the user object from the result of the sql and return user
            {
                DataRowCollection rows = result.Tables["Table"].Rows;
                DataRow row = rows[0];

                User u1 = new BusinessTier.User(Convert.ToInt32(row["UserID"]), Convert.ToString(row["UserName"]), Convert.ToString(row["Occupation"]));

                return u1;
                
            }
    }


    //
    // GetNamedUser:
    //
    // Retrieves User object based on USER NAME; returns null if user is not
    // found.
    //
    // NOTE: there are "named" users from the Users table, and anonymous users
    // that only exist in the Reviews table.  This function only looks up "named"
    // users from the Users table.
    //
    public User GetNamedUser(string UserName)
    {
            string sql = string.Format(@"Select * From Users Where UserName = '{0}';", UserName);
            DataSet result = dataTier.ExecuteNonScalarQuery(sql);

            //checks if username exists
            if (result.Tables[0].Rows.Count == 0)
            {
                return null;
            }
            else //create new user and return it
            {
                DataRowCollection rows = result.Tables["Table"].Rows;
                DataRow row = rows[0];

                User u = new BusinessTier.User(Convert.ToInt32(row["UserID"]), Convert.ToString(row["UserName"]), Convert.ToString(row["Occupation"]));

                return u;
            }      
    }


    //
    // GetAllNamedUsers:
    //
    // Returns a list of all the users in the Users table ("named" users), sorted 
    // by user name.
    //
    // NOTE: the database also contains lots of "anonymous" users, which this 
    // function does not return.
    //
    public IReadOnlyList<User> GetAllNamedUsers()
    {
      List<User> users = new List<User>();

            string sql = ("Select * From Users;");
            DataSet result = dataTier.ExecuteNonScalarQuery(sql);

            //creates a list of users and return it
            foreach(DataRow row in result.Tables["Table"].Rows)
            {
                User userToAdd = new BusinessTier.User(Convert.ToInt32(row["UserID"]), Convert.ToString(row["UserName"]), Convert.ToString(row["Occupation"]));

                users.Add(userToAdd);
            }
      
      return users;
    }


    //
    // GetMovie:
    //
    // Retrieves Movie object based on MOVIE ID; returns null if movie is not
    // found.
    //
    public Movie GetMovie(int MovieID)
    {
      string sql = string.Format(@"Select * From Movies Where MovieID = '{0}';", MovieID);

      DataSet result = dataTier.ExecuteNonScalarQuery(sql);

            //checks if movie id exists
            if(result.Tables[0].Rows.Count == 0)
            {
                return null;
            }
            else //return new movie object
            {
                DataRowCollection rows = result.Tables["Table"].Rows;
                DataRow row = rows[0];

                Movie m = new BusinessTier.Movie(MovieID, Convert.ToString(row["MovieName"]));

                return m;
            }      
    }


    //
    // GetMovie:
    //
    // Retrieves Movie object based on MOVIE NAME; returns null if movie is not
    // found.
    //
    public Movie GetMovie(string MovieName)
    {
            string sql = string.Format(@"Select * From Movies Where MovieName = '{0}';", MovieName);
            DataSet result = dataTier.ExecuteNonScalarQuery(sql);

            //checks if moviename exists
            if (result.Tables[0].Rows.Count == 0)
            {
                return null;
            }
            else //return movie object
            {
                DataRowCollection rows = result.Tables["Table"].Rows;
                DataRow row = rows[0];

                Movie m = new BusinessTier.Movie(Convert.ToInt32(row["MovieID"]), MovieName);

                return m;
            }      
    }


    //
    // AddReview:
    //
    // Adds review based on MOVIE ID, returning a Review object containing
    // the review, review's id, etc.  If the add failed, null is returned.
    //
    public Review AddReview(int MovieID, int UserID, int Rating)
    {
            string sql = string.Format(@"Insert Into Reviews(MovieID, UserID, Rating) Values('{0}', '{1}', '{2}');
                                         Select ReviewID From Reviews Where ReviewID = SCOPE_IDENTITY();", MovieID, UserID, Rating);

            object result = dataTier.ExecuteScalarQuery(sql);

            //checks if insert was successful, if so return the new review object
            if(result == null)
            {
                return null;
            }
            else
            {
                Review r = new BusinessTier.Review(Convert.ToInt32(result), MovieID, UserID, Rating);
                return r;
            }      
    }


    //
    // GetMovieDetail:
    //
    // Given a MOVIE ID, returns detailed information about this movie --- all
    // the reviews, the total number of reviews, average rating, etc.  If the 
    // movie cannot be found, null is returned.
    //
    public MovieDetail GetMovieDetail(int MovieID)
    {
            string sql1 = string.Format(@"Select * From Movies Where MovieID = '{0}';", MovieID);
            DataSet result = dataTier.ExecuteNonScalarQuery(sql1);

            //tests if movie id exists
            if (result.Tables[0].Rows.Count == 0)
            {
                return null;
            }
            else //Get the avg rating, number of reviews, and all reviews on the movie and return MovieDetail object
            {
                DataRowCollection rows1 = result.Tables["Table"].Rows;
                DataRow row = rows1[0];

                Movie m = new Movie(MovieID, Convert.ToString(row["MovieName"]));

                string sql2 = string.Format(@"Select ROUND(AVG(CONVERT(float,Rating)),4) From Reviews Where MovieID = '{0}';", MovieID);
                object avgRating = dataTier.ExecuteScalarQuery(sql2);

                string sql3 = string.Format(@"Select Count(*) as totalReview From Reviews Where MovieID = '{0}';", MovieID);
                object totalReviews = dataTier.ExecuteScalarQuery(sql3);

                string sql4 = string.Format(@"Select * From Reviews Where MovieID = '{0}' Order by Rating DESC, UserID;", MovieID);
                DataSet allReviews = dataTier.ExecuteNonScalarQuery(sql4);
                List<Review> reviews = new List<Review>();

                foreach (DataRow row2 in allReviews.Tables["Table"].Rows)
                {
                    Review reviewToAdd = new BusinessTier.Review(Convert.ToInt32(row2["ReviewID"]), MovieID, Convert.ToInt32(row2["UserID"]), Convert.ToInt32(row2["Rating"]));
                    reviews.Add(reviewToAdd);
                }


                MovieDetail movie = new BusinessTier.MovieDetail(m, Convert.ToDouble(avgRating), Convert.ToInt32(totalReviews), reviews);

                return movie;
            }      
    }


    //
    // GetUserDetail:
    //
    // Given a USER ID, returns detailed information about this user --- all
    // the reviews submitted by this user, the total number of reviews, average 
    // rating given, etc.  If the user cannot be found, null is returned.
    //
    public UserDetail GetUserDetail(int UserID)
    {
            string sql1 = string.Format(@"Select * From Users Where UserID = '{0}';", UserID);
            DataSet ifUserFound = dataTier.ExecuteNonScalarQuery(sql1);

            //checks if userID exists
            if (ifUserFound.Tables[0].Rows.Count == 0)
            {
                return null;
            }
            else //get user details, avg rating, number of reviews, and list of reviews and return UserDetail object
            {
                DataRowCollection rows = ifUserFound.Tables["Table"].Rows;
                DataRow row = rows[0];

                User userToAdd = new BusinessTier.User(UserID, Convert.ToString(row["UserName"]), Convert.ToString(row["Occupation"]));

                string sql2 = string.Format(@"Select ROUND(AVG(CONVERT(float,Rating)),4) From Reviews Where UserID = '{0}';", UserID);
                object avgRating = dataTier.ExecuteScalarQuery(sql2);

                string sql3 = string.Format(@"Select Count(*) as totalReview From Reviews Where UserID = '{0}';", UserID);
                object totalReviews = dataTier.ExecuteScalarQuery(sql3);

                string sql4 = string.Format(@"Select * From Reviews, Movies Where Reviews.MovieID = Movies.MovieID and UserID = '{0}' Order by Movies.MovieName, Reviews.Rating DESC ;", UserID);
                DataSet allReviews = dataTier.ExecuteNonScalarQuery(sql4);
                List<Review> reviews = new List<Review>();

                foreach (DataRow row2 in allReviews.Tables["Table"].Rows)
                {
                    Review reviewToAdd = new BusinessTier.Review(Convert.ToInt32(row2["ReviewID"]), Convert.ToInt32(row2["MovieID"]), UserID, Convert.ToInt32(row2["Rating"]));
                    reviews.Add(reviewToAdd);
                }

                UserDetail user = new BusinessTier.UserDetail(userToAdd, Convert.ToDouble(avgRating), Convert.ToInt32(totalReviews), reviews);

                return user;
            }      
    }


    //
    // GetTopMoviesByAvgRating:
    //
    // Returns the top N movies in descending order by average rating.  If two
    // movies have the same rating, the movies are presented in ascending order
    // by name.  If N < 1, an EMPTY LIST is returned.
    //
    public IReadOnlyList<Movie> GetTopMoviesByAvgRating(int N)
    {
      List<Movie> movies = new List<Movie>();

      string sql = string.Format(@"Select TOP {0} MovieName, ROUND(AVG(CONVERT(float,Rating)),4) as Avg From Reviews, Movies 
                                Where Reviews.MovieID = Movies.MovieID Group By Movies.MovieName Order By Avg DESC, MovieName ASC;", N);
            DataSet result = dataTier.ExecuteNonScalarQuery(sql);

            //checks if table is empty 
            if(result.Tables[0].Rows.Count == 0 || N < 1)
            {
                return movies;
            }
            else //display top N movies by rating on display
            {
                foreach (DataRow row in result.Tables["Table"].Rows)
                {
                        string sql2 = string.Format(@"Select MovieID From Movies Where MovieName = '{0}';", Convert.ToString(row["MovieName"]));
                        object MovieID = dataTier.ExecuteScalarQuery(sql2);

                        Movie movieToAdd = new BusinessTier.Movie(Convert.ToInt32(MovieID), Convert.ToString(row["MovieName"]));
                        movies.Add(movieToAdd);

                }
            }

      return movies;
    }


    //
    // GetTopMoviesByNumReviews
    //
    // Returns the top N movies in descending order by number of reviews.  If
    // two movies have the same number of reviews, the movies are presented in
    // ascending order by name.  If N < 1, an EMPTY LIST is returned.
    //
    public IReadOnlyList<Movie> GetTopMoviesByNumReviews(int N)
    {
      List<Movie> movies = new List<Movie>();

            string sql = string.Format(@"Select TOP {0} MovieName, Count(*) as totalReviews From Reviews, Movies 
                                         Where Reviews.MovieID = Movies.MovieID Group By Movies.MovieName Order By totalReviews DESC, MovieName ASC;", N);
            DataSet result = dataTier.ExecuteNonScalarQuery(sql);

            //checks if table is empty
            if (result.Tables[0].Rows.Count == 0 || N < 1)
            {
                return movies;
            }
            else //display top movies based on number of reviews on display box
            {
                foreach (DataRow row in result.Tables["Table"].Rows)
                {

                        string sql2 = string.Format(@"Select MovieID From Movies Where MovieName = '{0}';", Convert.ToString(row["MovieName"]));
                        object MovieID = dataTier.ExecuteScalarQuery(sql2);

                        Movie movieToAdd = new BusinessTier.Movie(Convert.ToInt32(MovieID), Convert.ToString(row["MovieName"]));
                        movies.Add(movieToAdd);


                }
            }

            return movies;
    }


    //
    // GetTopUsersByNumReviews
    //
    // Returns the top N users in descending order by number of reviews.  If two
    // users have the same number of reviews, the users are presented in ascending
    // order by user id.  If N < 1, an EMPTY LIST is returned.
    //
    // NOTE: not all user ids map to users in the Users table.  User ids that don't
    // map are considered "anonymous" users, and returned with their name = to their
    // userid ("<UserID>") and no occupation ("").
    //
    public IReadOnlyList<User> GetTopUsersByNumReviews(int N)
    {
      List<User> users = new List<User>();

      //
      // execute query to rank users:
      //
      // NOTE: some reviews are anonymous, i.e. don't have an entry in the Users
      // table.  So we use a "RIGHT JOIN" to capture those as well.
      //
      string sql = string.Format(@"SELECT TOP {0} Temp.UserID, Users.UserName, Users.Occupation
            FROM Users
            RIGHT JOIN
            (
              SELECT UserID, COUNT(*) AS RatingCount
              FROM Reviews
              GROUP BY UserID
            ) AS Temp
            On Temp.UserID = Users.UserID
            ORDER BY Temp.RatingCount DESC, Users.UserName Asc;",
        N);

            //
            // Now execute this query...  In the resulting dataset, the anonymous users will
            // have a UserName of "" because the result of the join was NULL.  So when you
            // come across a user with "" as their name, create a new User based on their user
            // id, i.e. string.Format("<{0}>", userid);
            //
            DataSet result = dataTier.ExecuteNonScalarQuery(sql);

            //checks if table is empty, if not insert user to display box
            if(result.Tables[0].Rows.Count == 0)
            {
                return users;
            }
            else
            {
                foreach (DataRow row in result.Tables["Table"].Rows)
                {

                    string userName = Convert.ToString(row["UserName"]);
                    if (userName == "") //checks if user was anonymous. if so make unique username
                    {
                        userName = string.Format("<{0}>", Convert.ToString(row["UserID"]));
                    }

                    User userToAdd = new User(Convert.ToInt32(row["UserID"]), userName, Convert.ToString(row["Occupation"]));
                    users.Add(userToAdd);
                }

                return users;
            }
    }

        //
        // GetAllMovies:
        //
        // Returns a list of all the movies in the database, sorted by movie name.
        //
        public IReadOnlyList<Movie> GetAllMovies()
        {
            List<Movie> movies = new List<Movie>();

            string sql = ("Select * From Movies Order By MovieName ASC;");
            DataSet result = dataTier.ExecuteNonScalarQuery(sql);

            foreach(DataRow row in result.Tables["Table"].Rows)
            {
                Movie movieToAdd = new BusinessTier.Movie(Convert.ToInt32(row["MovieID"]), Convert.ToString(row["MovieName"]));
                movies.Add(movieToAdd);
            }

            return movies;
        }

  }//class
}//namespace
