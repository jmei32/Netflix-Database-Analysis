//
// Netflix Database Application using N-Tier Design.
//
// Jim Mei
// U. of Illinois, Chicago
// CS341, Spring 2017
// Project 08
//

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
//using System.Threading.Tasks;
using System.Windows.Forms;
//using System.Data.SqlClient;

namespace Project7
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        //Function used to check if the file for the database exist in the debug/bin folder
        private bool fileExists(string filename)
        {
            if (!System.IO.File.Exists(filename))
            {
                string msg = string.Format("Input file not found: '{0}'",
                  filename);

                MessageBox.Show(msg);
                return false;
            }

            // exists!
            return true;
        }


        //Once the program starts, it will clear the listbox
        private void Form1_Load(object sender, EventArgs e)
        {
            this.clearForm();

            string filename = this.txtFilename.Text;

            BusinessTier.Business bizTier = new BusinessTier.Business(filename);

            if (!bizTier.TestConnection())
                return;
        }


        //Function used to clear the listbox
        private void clearForm()
        {
            this.display_box.Items.Clear();
        }


        //Accidental double click
        private void txtFilename_TextChanged(object sender, EventArgs e)
        {

        }


        //Function used to get all movies in the db
        private void All_Movies_Click(object sender, EventArgs e)
        {
            //check for db file
            string filename = this.txtFilename.Text;

            this.Cursor = Cursors.WaitCursor;

            //clears listbox
            clearForm();

            //Connect to business tier
            BusinessTier.Business bizTier = new BusinessTier.Business(filename);

            if (!bizTier.TestConnection())
                return;

            //Get list of movies from DB
            var allMovies = bizTier.GetAllMovies();

            //Add each movie to the display box
            foreach (BusinessTier.Movie movie in allMovies)
            {
                string msg = string.Format(@"{0}: {1}", movie.MovieID, movie.MovieName);

                this.display_box.Items.Add(msg);
            }

            this.Cursor = Cursors.Default;
        }


        //No clue why I made this
        private void display_box_SelectedIndexChanged(object sender, EventArgs e)
        {
            MessageBox.Show(this.display_box.Text);
        }


        //Get all users in db
        private void All_Users_Click(object sender, EventArgs e)
        {
            //check for db file
            string filename = this.txtFilename.Text;

            this.Cursor = Cursors.WaitCursor;

            //clears listbox
            clearForm();

            BusinessTier.Business bizTier = new BusinessTier.Business(filename);

            if (!bizTier.TestConnection())
                return;

            //gets the list of all the users
            var users = bizTier.GetAllNamedUsers();

            //Adds each user to the display box
            foreach(BusinessTier.User user in users)
            {
                string msg = string.Format(@"{0}: {1}", user.UserID, user.UserName);

                this.display_box.Items.Add(msg);
            }

            this.Cursor = Cursors.Default;
        }


        //function to check all the reviews for a movie
        private void Movie_Review_Click(object sender, EventArgs e)
        {
            //checks for db file
            string filename = this.txtFilename.Text;

            this.Cursor = Cursors.WaitCursor;

            //clears listbox
            clearForm();

            BusinessTier.Business bizTier = new BusinessTier.Business(filename);

            if (!bizTier.TestConnection())
                return;

            string moviename = this.txtMovieName.Text;

            //gets the data of the movie
            BusinessTier.Movie movie = bizTier.GetMovie(moviename);

            //checks if movie exists
            if (movie == null)
            {
                String MovieDNE = string.Format(@"Movie: {0} does not exist", moviename);
                MessageBox.Show(MovieDNE);
            }
            else //gets the movie details and add to display box
            {
                var movDetail = bizTier.GetMovieDetail(movie.MovieID);

                this.display_box.Items.Add(moviename); 

                foreach (BusinessTier.Review rating in movDetail.Reviews)
                {
                    string msg = string.Format("{0}: {1}", rating.UserID, rating.Rating);

                    this.display_box.Items.Add(msg);
                }
            }

            this.Cursor = Cursors.Default;
        }


        //Get all reviews by user
        private void User_Reviews_Click(object sender, EventArgs e)
        {
            //checks for db file
            string filename = this.txtFilename.Text;

            this.Cursor = Cursors.WaitCursor;

            //clears listbox
            clearForm();

            BusinessTier.Business bizTier = new BusinessTier.Business(filename);

            if (!bizTier.TestConnection())
                return;

            string username = this.txtUserName.Text;

            BusinessTier.User user = bizTier.GetNamedUser(username);

            //test if user exists
            if (user == null)
            {
                String UserDNE = string.Format(@"User: {0} does not exist", username);
                MessageBox.Show(UserDNE);
            }
            else //get user details and add to display box
            {
                var userDet = bizTier.GetUserDetail(user.UserID);

                this.display_box.Items.Add(username);

                foreach (BusinessTier.Review rating in userDet.Reviews)
                {
                    var movieName = bizTier.GetMovie(rating.MovieID);

                    string msg = string.Format("{0}: {1}", movieName.MovieName, rating.Rating);

                    this.display_box.Items.Add(msg);
                }
            }

            this.Cursor = Cursors.Default;
        }

        private void MovieList_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


        //insert review by user
        private void Insert_Review_Click(object sender, EventArgs e)
        {
            //checks for db file
            string filename = this.txtFilename.Text;

            this.Cursor = Cursors.WaitCursor;

            //clears listbox
            clearForm();

            BusinessTier.Business bizTier = new BusinessTier.Business(filename);

            if (!bizTier.TestConnection())
                return;

            string username = this.txtUserName.Text;

            BusinessTier.User user = bizTier.GetNamedUser(username);

            //test if user exists
            if (user == null)
            {
                String UserDNE = string.Format(@"User: {0} does not exist", username);
                MessageBox.Show(UserDNE);
            }
            else
            {
                string moviename = this.txtMovieName.Text;

                BusinessTier.Movie movie = bizTier.GetMovie(moviename);

                //test if movie exists
                if(movie == null)
                {
                    String MovieDNE = string.Format(@"Movie: {0} does not exist", moviename);
                    MessageBox.Show(MovieDNE);
                }
                else
                {
                    //insert review into db
                    int txtRating = Convert.ToInt32(this.RatingBox.Text);

                    var insertRev = bizTier.AddReview(movie.MovieID, user.UserID, txtRating);

                    if(insertRev == null)
                    {
                        MessageBox.Show("Insert failed");
                    }
                    else
                    {
                        string successMsg = string.Format(@"Insert successful. ReviewID: {0}",insertRev.ReviewID);
                        MessageBox.Show(successMsg);
                    }
                }
                
            }

            this.Cursor = Cursors.Default;
        }


        //accidental double click. Removing these seems to cause errors
        private void Form1_Load_1(object sender, EventArgs e)
        {
            string filename = this.txtFilename.Text;

            BusinessTier.Business bizTier = new BusinessTier.Business(filename);

            if (!bizTier.TestConnection())
                return;
        }


        //Get avg review for movie
        private void Avg_Rating_Click(object sender, EventArgs e)
        {
            //checks for db file
            string filename = this.txtFilename.Text;

            this.Cursor = Cursors.WaitCursor;

            //clears listbox
            clearForm();

            BusinessTier.Business bizTier = new BusinessTier.Business(filename);

            if (!bizTier.TestConnection())
                return;

            string moviename = this.txtMovieName.Text;

            BusinessTier.Movie movie = bizTier.GetMovie(moviename);

            //check if movie exists
            if (movie == null)
            {
                String MovieDNE = string.Format(@"Movie: {0} does not exist", moviename);
                MessageBox.Show(MovieDNE);
            }
            else
            {
                //get the movie details and display the movie's average rating
                var movDetail = bizTier.GetMovieDetail(movie.MovieID);

                this.display_box.Items.Add(moviename);

                string rating = string.Format("{0:0.00}", Convert.ToDecimal(movDetail.AvgRating));

                string msg = string.Format("Average Rating: {0}", rating);

                this.display_box.Items.Add(msg);
            }

            this.Cursor = Cursors.Default;
        }


        //Get the amount of each rating for a movie
        private void All_Rating_Click(object sender, EventArgs e)
        {
            //checks for db file
            string filename = this.txtFilename.Text;

            this.Cursor = Cursors.WaitCursor;

            //clears listbox
            clearForm();

            BusinessTier.Business bizTier = new BusinessTier.Business(filename);

            if (!bizTier.TestConnection())
                return;

            string moviename = this.txtMovieName.Text;

            BusinessTier.Movie movie = bizTier.GetMovie(moviename);

            //test if movie exists
            if (movie == null)
            {
                String MovieDNE = string.Format(@"Movie: {0} does not exist", moviename);
                MessageBox.Show(MovieDNE);
            }
            else
            {
                //count the number of each rating and add them to display box
                var movDetail = bizTier.GetMovieDetail(movie.MovieID);

                this.display_box.Items.Add(moviename);

                int score5 = 0;
                int score4 = 0;
                int score3 = 0;
                int score2 = 0;
                int score1 = 0;

                foreach (BusinessTier.Review reviews in movDetail.Reviews)
                {
                    int temp = reviews.Rating;

                    if (temp == 5)
                        score5++;
                    else if (temp == 4)
                        score4++;
                    else if (temp == 3)
                        score3++;
                    else if (temp == 2)
                        score2++;
                    else
                        score1++;
                }

                string rating5 = string.Format("5: {0}", score5);
                string rating4 = string.Format("4: {0}", score4);
                string rating3 = string.Format("3: {0}", score3);
                string rating2 = string.Format("2: {0}", score2);
                string rating1 = string.Format("1: {0}", score1);
                string total = string.Format("Total: {0}", movDetail.NumReviews);

                this.display_box.Items.Add(rating5);
                this.display_box.Items.Add(rating4);
                this.display_box.Items.Add(rating3);
                this.display_box.Items.Add(rating2);
                this.display_box.Items.Add(rating1);
                this.display_box.Items.Add(total);
            }

            this.Cursor = Cursors.Default;
        }


        private void txtMovieName_TextChanged(object sender, EventArgs e)
        {

        }


        //display top rating movies
        private void Top_Movies_Click(object sender, EventArgs e)
        {
            //checks for db file
            string filename = this.txtFilename.Text;

            this.Cursor = Cursors.WaitCursor;

            //clears listbox
            clearForm();

            BusinessTier.Business bizTier = new BusinessTier.Business(filename);

            if (!bizTier.TestConnection())
                return;

            string moviename = this.txtMovieName.Text;

            int topN = Convert.ToInt32(this.N_list.Text);

            //checks if an int was inputted by user
            if (!int.TryParse(N_list.Text, out topN))
            {
                MessageBox.Show("This is a number only field. Please try again");
            }
            else
            {
                //get a list of the Top N movies based on average rating and add them to display box 
                var topNList = bizTier.GetTopMoviesByAvgRating(topN);

                string header = string.Format(@"Top {0} Movies", topN);

                this.display_box.Items.Add(header);

                foreach (var curMovie in topNList)
                {
                    var movieDetails = bizTier.GetMovieDetail(curMovie.MovieID);

                    string msg = string.Format(@"{0}: {1}", curMovie.MovieName, movieDetails.AvgRating);

                    this.display_box.Items.Add(msg);
                }

            }

            this.Cursor = Cursors.Default;
        }


        //top N users - most reviews
        private void N_users_Click(object sender, EventArgs e)
        {
            //checks for db file
            string filename = this.txtFilename.Text;

            this.Cursor = Cursors.WaitCursor;

            //clears listbox
            clearForm();

            BusinessTier.Business bizTier = new BusinessTier.Business(filename);

            if (!bizTier.TestConnection())
                return;

            string moviename = this.txtMovieName.Text;

            int topN = Convert.ToInt32(this.N_list.Text);

            //checks if an int was inputted by user
            if (!int.TryParse(N_list.Text, out topN))
            {
                MessageBox.Show("This is a number only field. Please try again");
            }
            else
            {
                //get a list of top N users based on number of reviews and insert to display box
                var topNList = bizTier.GetTopUsersByNumReviews(topN);

                string header = string.Format(@"Top {0} Users", topN);

                this.display_box.Items.Add(header);

                foreach (var curUser in topNList)
                {
                    var userDetails = bizTier.GetUserDetail(curUser.UserID);

                    string msg = string.Format(@"{0}: {1}", curUser.UserName, userDetails.NumReviews);

                    this.display_box.Items.Add(msg);
                }

            }

            this.Cursor = Cursors.Default;
        }


        private void searchMovieID_Click(object sender, EventArgs e)
        {
            //check for db file
            string filename = this.txtFilename.Text;

            this.Cursor = Cursors.WaitCursor;

            //clears listbox
            clearForm();

            BusinessTier.Business bizTier = new BusinessTier.Business(filename);

            if (!bizTier.TestConnection())
                return;

            int movieID = Convert.ToInt32(this.txtMovieID.Text);

            //checks if an int was inputted by user
            if (!int.TryParse(txtMovieID.Text, out movieID))
            {
                MessageBox.Show("This is a number only field. Please try again");
            }
            else
            {
                var movie = bizTier.GetMovie(movieID);

                //checks if movie exists
                if (movie == null)
                {
                    MessageBox.Show("Movie ID is not in the list");
                }
                else
                {
                    string msg = string.Format(@"Movie ID: {0} - {1}", movieID, movie.MovieName);

                    MessageBox.Show(msg);
                }
            }
            this.Cursor = Cursors.Default;
        }


        private void N_list_TextChanged(object sender, EventArgs e)
        {

        }


        private void txtMovieID_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtUserName_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void searchUserID_Click(object sender, EventArgs e)
        {
            //check for db file
            string filename = this.txtFilename.Text;

            this.Cursor = Cursors.WaitCursor;

            //clears listbox
            clearForm();

            BusinessTier.Business bizTier = new BusinessTier.Business(filename);

            if (!bizTier.TestConnection())
                return;

            int userID = Convert.ToInt32(this.txtUserID.Text);

            //checks if an int was inputted by user
            if (!int.TryParse(txtUserID.Text, out userID))
            {
                MessageBox.Show("This is a number only field. Please try again");
            }
            else
            {
                var user = bizTier.GetUser(userID);

                if (user == null)
                {
                    MessageBox.Show("User ID is not a user");
                }
                else
                {
                    string msg = string.Format(@"User ID: {0} - {1}", userID, user.UserName);

                    MessageBox.Show(msg);
                }
            }
            this.Cursor = Cursors.Default;
        }


        private void button1_Click(object sender, EventArgs e)
        {
            //checks for db file
            string filename = this.txtFilename.Text;

            this.Cursor = Cursors.WaitCursor;

            //clears listbox
            clearForm();

            BusinessTier.Business bizTier = new BusinessTier.Business(filename);

            if (!bizTier.TestConnection())
                return;

            string moviename = this.txtMovieName.Text;

            int topN = Convert.ToInt32(this.N_list.Text);

            //checks if an int was inputted by user
            if (!int.TryParse(N_list.Text, out topN))
            {
                MessageBox.Show("This is a number only field. Please try again");
            }
            else
            {
                var topNList = bizTier.GetTopMoviesByNumReviews(topN);

                string header = string.Format(@"Top {0} Movies", topN);

                this.display_box.Items.Add(header);

                foreach (var curMovie in topNList)
                {
                    var movieDetails = bizTier.GetMovieDetail(curMovie.MovieID);

                    string msg = string.Format(@"{0}: {1}", curMovie.MovieName, movieDetails.NumReviews);

                    this.display_box.Items.Add(msg);
                }

            }
            this.Cursor = Cursors.Default;
        }
    }
}
