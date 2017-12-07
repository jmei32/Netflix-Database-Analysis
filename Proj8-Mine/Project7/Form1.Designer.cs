namespace Project7
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtFilename = new System.Windows.Forms.TextBox();
            this.All_Movies = new System.Windows.Forms.Button();
            this.display_box = new System.Windows.Forms.ListBox();
            this.All_Users = new System.Windows.Forms.Button();
            this.Movie_Review = new System.Windows.Forms.Button();
            this.txtMovieName = new System.Windows.Forms.TextBox();
            this.User_Reviews = new System.Windows.Forms.Button();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.Insert_Review = new System.Windows.Forms.Button();
            this.RatingBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.Avg_Rating = new System.Windows.Forms.Button();
            this.All_Rating = new System.Windows.Forms.Button();
            this.Top_Movies = new System.Windows.Forms.Button();
            this.N_list = new System.Windows.Forms.TextBox();
            this.N_users = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.txtMovieID = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.searchMovieID = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.txtUserID = new System.Windows.Forms.TextBox();
            this.searchUserID = new System.Windows.Forms.Button();
            this.Top_N_Movies_Rev = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtFilename
            // 
            this.txtFilename.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFilename.Location = new System.Drawing.Point(12, 443);
            this.txtFilename.Name = "txtFilename";
            this.txtFilename.Size = new System.Drawing.Size(676, 26);
            this.txtFilename.TabIndex = 0;
            this.txtFilename.Text = "netflix.mdf";
            this.txtFilename.TextChanged += new System.EventHandler(this.txtFilename_TextChanged);
            // 
            // All_Movies
            // 
            this.All_Movies.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.All_Movies.Location = new System.Drawing.Point(12, 12);
            this.All_Movies.Name = "All_Movies";
            this.All_Movies.Size = new System.Drawing.Size(126, 38);
            this.All_Movies.TabIndex = 1;
            this.All_Movies.Text = "All Movies";
            this.All_Movies.UseVisualStyleBackColor = true;
            this.All_Movies.Click += new System.EventHandler(this.All_Movies_Click);
            // 
            // display_box
            // 
            this.display_box.FormattingEnabled = true;
            this.display_box.Location = new System.Drawing.Point(361, 12);
            this.display_box.Name = "display_box";
            this.display_box.Size = new System.Drawing.Size(327, 407);
            this.display_box.TabIndex = 2;
            this.display_box.SelectedIndexChanged += new System.EventHandler(this.display_box_SelectedIndexChanged);
            // 
            // All_Users
            // 
            this.All_Users.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.All_Users.Location = new System.Drawing.Point(12, 56);
            this.All_Users.Name = "All_Users";
            this.All_Users.Size = new System.Drawing.Size(126, 44);
            this.All_Users.TabIndex = 3;
            this.All_Users.Text = "All Users";
            this.All_Users.UseVisualStyleBackColor = true;
            this.All_Users.Click += new System.EventHandler(this.All_Users_Click);
            // 
            // Movie_Review
            // 
            this.Movie_Review.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Movie_Review.Location = new System.Drawing.Point(12, 106);
            this.Movie_Review.Name = "Movie_Review";
            this.Movie_Review.Size = new System.Drawing.Size(126, 45);
            this.Movie_Review.TabIndex = 4;
            this.Movie_Review.Text = "Movie Reviews";
            this.Movie_Review.UseVisualStyleBackColor = true;
            this.Movie_Review.Click += new System.EventHandler(this.Movie_Review_Click);
            // 
            // txtMovieName
            // 
            this.txtMovieName.Location = new System.Drawing.Point(201, 28);
            this.txtMovieName.Name = "txtMovieName";
            this.txtMovieName.Size = new System.Drawing.Size(125, 20);
            this.txtMovieName.TabIndex = 5;
            this.txtMovieName.Text = "12 Angry Men";
            this.txtMovieName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtMovieName.TextChanged += new System.EventHandler(this.txtMovieName_TextChanged);
            // 
            // User_Reviews
            // 
            this.User_Reviews.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.User_Reviews.Location = new System.Drawing.Point(12, 157);
            this.User_Reviews.Name = "User_Reviews";
            this.User_Reviews.Size = new System.Drawing.Size(126, 43);
            this.User_Reviews.TabIndex = 6;
            this.User_Reviews.Text = "User Reviews";
            this.User_Reviews.UseVisualStyleBackColor = true;
            this.User_Reviews.Click += new System.EventHandler(this.User_Reviews_Click);
            // 
            // txtUserName
            // 
            this.txtUserName.Location = new System.Drawing.Point(201, 67);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(125, 20);
            this.txtUserName.TabIndex = 7;
            this.txtUserName.Text = "Drago";
            this.txtUserName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtUserName.TextChanged += new System.EventHandler(this.txtUserName_TextChanged);
            // 
            // Insert_Review
            // 
            this.Insert_Review.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Insert_Review.Location = new System.Drawing.Point(12, 205);
            this.Insert_Review.Name = "Insert_Review";
            this.Insert_Review.Size = new System.Drawing.Size(126, 40);
            this.Insert_Review.TabIndex = 8;
            this.Insert_Review.Text = "Insert Review";
            this.Insert_Review.UseVisualStyleBackColor = true;
            this.Insert_Review.Click += new System.EventHandler(this.Insert_Review_Click);
            // 
            // RatingBox
            // 
            this.RatingBox.FormattingEnabled = true;
            this.RatingBox.Items.AddRange(new object[] {
            "5",
            "4",
            "3",
            "2",
            "1"});
            this.RatingBox.Location = new System.Drawing.Point(201, 106);
            this.RatingBox.Name = "RatingBox";
            this.RatingBox.Size = new System.Drawing.Size(125, 21);
            this.RatingBox.TabIndex = 11;
            this.RatingBox.Text = "5";
            this.RatingBox.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(233, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "Enter Movie";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(233, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 13);
            this.label2.TabIndex = 13;
            this.label2.Text = "Enter User";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(226, 90);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 13);
            this.label3.TabIndex = 14;
            this.label3.Text = "Select Rating";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // Avg_Rating
            // 
            this.Avg_Rating.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Avg_Rating.Location = new System.Drawing.Point(12, 251);
            this.Avg_Rating.Name = "Avg_Rating";
            this.Avg_Rating.Size = new System.Drawing.Size(126, 39);
            this.Avg_Rating.TabIndex = 15;
            this.Avg_Rating.Text = "Avg Rating";
            this.Avg_Rating.UseVisualStyleBackColor = true;
            this.Avg_Rating.Click += new System.EventHandler(this.Avg_Rating_Click);
            // 
            // All_Rating
            // 
            this.All_Rating.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.All_Rating.Location = new System.Drawing.Point(12, 296);
            this.All_Rating.Name = "All_Rating";
            this.All_Rating.Size = new System.Drawing.Size(126, 44);
            this.All_Rating.TabIndex = 16;
            this.All_Rating.Text = "Movie Ratings";
            this.All_Rating.UseVisualStyleBackColor = true;
            this.All_Rating.Click += new System.EventHandler(this.All_Rating_Click);
            // 
            // Top_Movies
            // 
            this.Top_Movies.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Top_Movies.Location = new System.Drawing.Point(12, 393);
            this.Top_Movies.Name = "Top_Movies";
            this.Top_Movies.Size = new System.Drawing.Size(126, 41);
            this.Top_Movies.TabIndex = 17;
            this.Top_Movies.Text = "Top-N Movies";
            this.Top_Movies.UseVisualStyleBackColor = true;
            this.Top_Movies.Click += new System.EventHandler(this.Top_Movies_Click);
            // 
            // N_list
            // 
            this.N_list.Location = new System.Drawing.Point(201, 146);
            this.N_list.Name = "N_list";
            this.N_list.Size = new System.Drawing.Size(125, 20);
            this.N_list.TabIndex = 18;
            this.N_list.Text = "5";
            this.N_list.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.N_list.TextChanged += new System.EventHandler(this.N_list_TextChanged);
            // 
            // N_users
            // 
            this.N_users.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.N_users.Location = new System.Drawing.Point(12, 346);
            this.N_users.Name = "N_users";
            this.N_users.Size = new System.Drawing.Size(126, 44);
            this.N_users.TabIndex = 19;
            this.N_users.Text = "Top-N Users";
            this.N_users.UseVisualStyleBackColor = true;
            this.N_users.Click += new System.EventHandler(this.N_users_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(226, 130);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(84, 13);
            this.label4.TabIndex = 20;
            this.label4.Text = "Top N Selection";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // txtMovieID
            // 
            this.txtMovieID.Location = new System.Drawing.Point(201, 221);
            this.txtMovieID.Name = "txtMovieID";
            this.txtMovieID.Size = new System.Drawing.Size(125, 20);
            this.txtMovieID.TabIndex = 21;
            this.txtMovieID.Text = "7";
            this.txtMovieID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtMovieID.TextChanged += new System.EventHandler(this.txtMovieID_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(233, 205);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(50, 13);
            this.label5.TabIndex = 22;
            this.label5.Text = "Movie ID";
            // 
            // searchMovieID
            // 
            this.searchMovieID.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.searchMovieID.Location = new System.Drawing.Point(201, 247);
            this.searchMovieID.Name = "searchMovieID";
            this.searchMovieID.Size = new System.Drawing.Size(125, 38);
            this.searchMovieID.TabIndex = 23;
            this.searchMovieID.Text = "Search Movie ID";
            this.searchMovieID.UseVisualStyleBackColor = true;
            this.searchMovieID.Click += new System.EventHandler(this.searchMovieID_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(233, 288);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(43, 13);
            this.label6.TabIndex = 24;
            this.label6.Text = "User ID";
            // 
            // txtUserID
            // 
            this.txtUserID.Location = new System.Drawing.Point(201, 304);
            this.txtUserID.Name = "txtUserID";
            this.txtUserID.Size = new System.Drawing.Size(125, 20);
            this.txtUserID.TabIndex = 25;
            this.txtUserID.Text = "2439493";
            this.txtUserID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // searchUserID
            // 
            this.searchUserID.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.searchUserID.Location = new System.Drawing.Point(201, 331);
            this.searchUserID.Name = "searchUserID";
            this.searchUserID.Size = new System.Drawing.Size(125, 37);
            this.searchUserID.TabIndex = 26;
            this.searchUserID.Text = "Search User ID";
            this.searchUserID.UseVisualStyleBackColor = true;
            this.searchUserID.Click += new System.EventHandler(this.searchUserID_Click);
            // 
            // Top_N_Movies_Rev
            // 
            this.Top_N_Movies_Rev.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Top_N_Movies_Rev.Location = new System.Drawing.Point(144, 392);
            this.Top_N_Movies_Rev.Name = "Top_N_Movies_Rev";
            this.Top_N_Movies_Rev.Size = new System.Drawing.Size(125, 44);
            this.Top_N_Movies_Rev.TabIndex = 27;
            this.Top_N_Movies_Rev.Text = "Top-N Rev Movies";
            this.Top_N_Movies_Rev.UseVisualStyleBackColor = true;
            this.Top_N_Movies_Rev.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(700, 475);
            this.Controls.Add(this.Top_N_Movies_Rev);
            this.Controls.Add(this.searchUserID);
            this.Controls.Add(this.txtUserID);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.searchMovieID);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtMovieID);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.N_users);
            this.Controls.Add(this.N_list);
            this.Controls.Add(this.Top_Movies);
            this.Controls.Add(this.All_Rating);
            this.Controls.Add(this.Avg_Rating);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.RatingBox);
            this.Controls.Add(this.Insert_Review);
            this.Controls.Add(this.txtUserName);
            this.Controls.Add(this.User_Reviews);
            this.Controls.Add(this.txtMovieName);
            this.Controls.Add(this.Movie_Review);
            this.Controls.Add(this.All_Users);
            this.Controls.Add(this.display_box);
            this.Controls.Add(this.All_Movies);
            this.Controls.Add(this.txtFilename);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load_1);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtFilename;
        private System.Windows.Forms.Button All_Movies;
        private System.Windows.Forms.ListBox display_box;
        private System.Windows.Forms.Button All_Users;
        private System.Windows.Forms.Button Movie_Review;
        private System.Windows.Forms.TextBox txtMovieName;
        private System.Windows.Forms.Button User_Reviews;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.Button Insert_Review;
        private System.Windows.Forms.ComboBox RatingBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button Avg_Rating;
        private System.Windows.Forms.Button All_Rating;
        private System.Windows.Forms.Button Top_Movies;
        private System.Windows.Forms.TextBox N_list;
        private System.Windows.Forms.Button N_users;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtMovieID;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button searchMovieID;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtUserID;
        private System.Windows.Forms.Button searchUserID;
        private System.Windows.Forms.Button Top_N_Movies_Rev;
    }
}

