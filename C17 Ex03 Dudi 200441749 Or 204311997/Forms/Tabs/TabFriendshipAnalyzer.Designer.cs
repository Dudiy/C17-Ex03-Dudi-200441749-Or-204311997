﻿namespace C17_Ex01_Dudi_200441749_Or_204311997.Forms.Tabs
{
    using C17_Ex01_Dudi_200441749_Or_204311997.ControlsAndProxies;

    partial class TabFriendshipAnalyzer
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
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TabFriendshipAnalyzer));
            this.panelGeneralInfo = new System.Windows.Forms.Panel();
            this.listBoxPhotosCommentedOn = new System.Windows.Forms.ListBox();
            this.buttonFetchGeneralData = new System.Windows.Forms.Button();
            this.labelNumComments = new System.Windows.Forms.Label();
            this.labelLastName = new System.Windows.Forms.Label();
            this.labelFirstName = new System.Windows.Forms.Label();
            this.buttonFetchMyPhotosFriendIsIn = new System.Windows.Forms.Button();
            this.buttonFetchTaggedTogether = new System.Windows.Forms.Button();
            this.labelNumLikes = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonFetchPhotosOfFriendIAmTaggedIn = new System.Windows.Forms.Button();
            this.treeViewPhotosOfFriendIAmTaggedIn = new C17_Ex01_Dudi_200441749_Or_204311997.ControlsAndProxies.TreeViewExtenderForFacebookPhotos();
            this.treeViewTaggedTogether = new C17_Ex01_Dudi_200441749_Or_204311997.ControlsAndProxies.TreeViewExtenderForFacebookPhotos();
            this.treeViewPhotosOfFriendInMyPhotos = new C17_Ex01_Dudi_200441749_Or_204311997.ControlsAndProxies.TreeViewExtenderForFacebookPhotos();
            this.pictureBoxMostRecentTaggedTogether = new C17_Ex01_Dudi_200441749_Or_204311997.ControlsAndProxies.GrowingPictureBoxProxy();
            this.flowLayoutPanelExtenderForFacebookFriends = new C17_Ex01_Dudi_200441749_Or_204311997.ControlsAndProxies.FlowLayoutPanelExtenderForFacebookFriends();
            this.panelGeneralInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMostRecentTaggedTogether)).BeginInit();
            this.SuspendLayout();
            // 
            // panelGeneralInfo
            // 
            this.panelGeneralInfo.AutoScroll = true;
            this.panelGeneralInfo.Controls.Add(this.listBoxPhotosCommentedOn);
            this.panelGeneralInfo.Controls.Add(this.treeViewPhotosOfFriendIAmTaggedIn);
            this.panelGeneralInfo.Controls.Add(this.treeViewTaggedTogether);
            this.panelGeneralInfo.Controls.Add(this.treeViewPhotosOfFriendInMyPhotos);
            this.panelGeneralInfo.Controls.Add(this.pictureBoxMostRecentTaggedTogether);
            this.panelGeneralInfo.Controls.Add(this.buttonFetchGeneralData);
            this.panelGeneralInfo.Controls.Add(this.labelNumComments);
            this.panelGeneralInfo.Controls.Add(this.labelLastName);
            this.panelGeneralInfo.Controls.Add(this.labelFirstName);
            this.panelGeneralInfo.Controls.Add(this.buttonFetchMyPhotosFriendIsIn);
            this.panelGeneralInfo.Controls.Add(this.buttonFetchTaggedTogether);
            this.panelGeneralInfo.Controls.Add(this.labelNumLikes);
            this.panelGeneralInfo.Controls.Add(this.label1);
            this.panelGeneralInfo.Controls.Add(this.buttonFetchPhotosOfFriendIAmTaggedIn);
            this.panelGeneralInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelGeneralInfo.Location = new System.Drawing.Point(184, 0);
            this.panelGeneralInfo.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panelGeneralInfo.Name = "panelGeneralInfo";
            this.panelGeneralInfo.Size = new System.Drawing.Size(984, 450);
            this.panelGeneralInfo.TabIndex = 3;
            this.panelGeneralInfo.Visible = false;
            // 
            // listBoxPhotosCommentedOn
            // 
            this.listBoxPhotosCommentedOn.FormattingEnabled = true;
            this.listBoxPhotosCommentedOn.ItemHeight = 20;
            this.listBoxPhotosCommentedOn.Location = new System.Drawing.Point(26, 355);
            this.listBoxPhotosCommentedOn.Name = "listBoxPhotosCommentedOn";
            this.listBoxPhotosCommentedOn.Size = new System.Drawing.Size(346, 144);
            this.listBoxPhotosCommentedOn.TabIndex = 23;
            this.listBoxPhotosCommentedOn.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listBoxPhotosCommentedOn_MouseDoubleClick);
            // 
            // buttonFetchGeneralData
            // 
            this.buttonFetchGeneralData.Location = new System.Drawing.Point(24, 195);
            this.buttonFetchGeneralData.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonFetchGeneralData.Name = "buttonFetchGeneralData";
            this.buttonFetchGeneralData.Size = new System.Drawing.Size(170, 35);
            this.buttonFetchGeneralData.TabIndex = 13;
            this.buttonFetchGeneralData.Text = "Fetch Statistics";
            this.buttonFetchGeneralData.UseVisualStyleBackColor = true;
            this.buttonFetchGeneralData.Click += new System.EventHandler(this.buttonFetchGeneralData_Click);
            // 
            // labelNumComments
            // 
            this.labelNumComments.Location = new System.Drawing.Point(20, 303);
            this.labelNumComments.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelNumComments.Name = "labelNumComments";
            this.labelNumComments.Size = new System.Drawing.Size(370, 49);
            this.labelNumComments.TabIndex = 3;
            this.labelNumComments.Text = "Number of times {0} commented on my photos";
            this.labelNumComments.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelLastName
            // 
            this.labelLastName.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.labelLastName.Location = new System.Drawing.Point(16, 94);
            this.labelLastName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelLastName.Name = "labelLastName";
            this.labelLastName.Size = new System.Drawing.Size(380, 54);
            this.labelLastName.TabIndex = 1;
            this.labelLastName.Text = "Last Name";
            // 
            // labelFirstName
            // 
            this.labelFirstName.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.labelFirstName.Location = new System.Drawing.Point(16, 40);
            this.labelFirstName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelFirstName.Name = "labelFirstName";
            this.labelFirstName.Size = new System.Drawing.Size(380, 54);
            this.labelFirstName.TabIndex = 0;
            this.labelFirstName.Text = "First Name";
            // 
            // buttonFetchMyPhotosFriendIsIn
            // 
            this.buttonFetchMyPhotosFriendIsIn.Location = new System.Drawing.Point(399, 6);
            this.buttonFetchMyPhotosFriendIsIn.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonFetchMyPhotosFriendIsIn.Name = "buttonFetchMyPhotosFriendIsIn";
            this.buttonFetchMyPhotosFriendIsIn.Size = new System.Drawing.Size(372, 46);
            this.buttonFetchMyPhotosFriendIsIn.TabIndex = 5;
            this.buttonFetchMyPhotosFriendIsIn.Text = "Fetch photos of mine {friend} is in";
            this.buttonFetchMyPhotosFriendIsIn.UseVisualStyleBackColor = true;
            this.buttonFetchMyPhotosFriendIsIn.Click += new System.EventHandler(this.buttonFetchMyPhotosFriendIsIn_Click);
            // 
            // buttonFetchTaggedTogether
            // 
            this.buttonFetchTaggedTogether.Location = new System.Drawing.Point(780, 6);
            this.buttonFetchTaggedTogether.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonFetchTaggedTogether.Name = "buttonFetchTaggedTogether";
            this.buttonFetchTaggedTogether.Size = new System.Drawing.Size(372, 46);
            this.buttonFetchTaggedTogether.TabIndex = 8;
            this.buttonFetchTaggedTogether.Text = "Fetch photos tagged together";
            this.buttonFetchTaggedTogether.UseVisualStyleBackColor = true;
            // 
            // labelNumLikes
            // 
            this.labelNumLikes.Location = new System.Drawing.Point(20, 254);
            this.labelNumLikes.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelNumLikes.Name = "labelNumLikes";
            this.labelNumLikes.Size = new System.Drawing.Size(370, 49);
            this.labelNumLikes.TabIndex = 2;
            this.labelNumLikes.Text = "Number of times {0} liked my photos";
            this.labelNumLikes.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 546);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(256, 20);
            this.label1.TabIndex = 4;
            this.label1.Text = "Most recent photo tagged together";
            // 
            // buttonFetchPhotosOfFriendIAmTaggedIn
            // 
            this.buttonFetchPhotosOfFriendIAmTaggedIn.Location = new System.Drawing.Point(1161, 6);
            this.buttonFetchPhotosOfFriendIAmTaggedIn.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonFetchPhotosOfFriendIAmTaggedIn.Name = "buttonFetchPhotosOfFriendIAmTaggedIn";
            this.buttonFetchPhotosOfFriendIAmTaggedIn.Size = new System.Drawing.Size(372, 46);
            this.buttonFetchPhotosOfFriendIAmTaggedIn.TabIndex = 10;
            this.buttonFetchPhotosOfFriendIAmTaggedIn.Text = "Fetch Friend\'s Photos I am Tagged in";
            this.buttonFetchPhotosOfFriendIAmTaggedIn.UseVisualStyleBackColor = true;
            // 
            // treeViewPhotosOfFriendIAmTaggedIn
            // 
            this.treeViewPhotosOfFriendIAmTaggedIn.Location = new System.Drawing.Point(1164, 63);
            this.treeViewPhotosOfFriendIAmTaggedIn.Name = "treeViewPhotosOfFriendIAmTaggedIn";
            this.treeViewPhotosOfFriendIAmTaggedIn.Size = new System.Drawing.Size(370, 739);
            this.treeViewPhotosOfFriendIAmTaggedIn.TabIndex = 22;
            // 
            // treeViewTaggedTogether
            // 
            this.treeViewTaggedTogether.Location = new System.Drawing.Point(784, 65);
            this.treeViewTaggedTogether.Name = "treeViewTaggedTogether";
            this.treeViewTaggedTogether.Size = new System.Drawing.Size(370, 739);
            this.treeViewTaggedTogether.TabIndex = 21;
            // 
            // treeViewPhotosOfFriendInMyPhotos
            // 
            this.treeViewPhotosOfFriendInMyPhotos.Location = new System.Drawing.Point(399, 65);
            this.treeViewPhotosOfFriendInMyPhotos.Name = "treeViewPhotosOfFriendInMyPhotos";
            this.treeViewPhotosOfFriendInMyPhotos.Size = new System.Drawing.Size(370, 739);
            this.treeViewPhotosOfFriendInMyPhotos.TabIndex = 20;
            // 
            // pictureBoxMostRecentTaggedTogether
            // 
            this.pictureBoxMostRecentTaggedTogether.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxMostRecentTaggedTogether.Image")));
            this.pictureBoxMostRecentTaggedTogether.Location = new System.Drawing.Point(24, 583);
            this.pictureBoxMostRecentTaggedTogether.Name = "pictureBoxMostRecentTaggedTogether";
            this.pictureBoxMostRecentTaggedTogether.Size = new System.Drawing.Size(350, 222);
            this.pictureBoxMostRecentTaggedTogether.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxMostRecentTaggedTogether.TabIndex = 14;
            this.pictureBoxMostRecentTaggedTogether.TabStop = false;
            this.pictureBoxMostRecentTaggedTogether.Click += new System.EventHandler(this.pictureBoxMostRecentTaggedTogether_Click);
            // 
            // flowLayoutPanelExtenderForFacebookFriends
            // 
            this.flowLayoutPanelExtenderForFacebookFriends.AutoScroll = true;
            this.flowLayoutPanelExtenderForFacebookFriends.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.flowLayoutPanelExtenderForFacebookFriends.Dock = System.Windows.Forms.DockStyle.Left;
            this.flowLayoutPanelExtenderForFacebookFriends.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanelExtenderForFacebookFriends.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.flowLayoutPanelExtenderForFacebookFriends.Name = "flowLayoutPanelExtenderForFacebookFriends";
            this.flowLayoutPanelExtenderForFacebookFriends.Size = new System.Drawing.Size(184, 450);
            this.flowLayoutPanelExtenderForFacebookFriends.TabIndex = 4;
            // 
            // TabFriendshipAnalyzer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelGeneralInfo);
            this.Controls.Add(this.flowLayoutPanelExtenderForFacebookFriends);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "TabFriendshipAnalyzer";
            this.Size = new System.Drawing.Size(1168, 450);
            this.panelGeneralInfo.ResumeLayout(false);
            this.panelGeneralInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMostRecentTaggedTogether)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelGeneralInfo;
        private System.Windows.Forms.ListBox listBoxPhotosCommentedOn;
        private TreeViewExtenderForFacebookPhotos treeViewPhotosOfFriendIAmTaggedIn;
        private TreeViewExtenderForFacebookPhotos treeViewTaggedTogether;
        private TreeViewExtenderForFacebookPhotos treeViewPhotosOfFriendInMyPhotos;
        private GrowingPictureBoxProxy pictureBoxMostRecentTaggedTogether;
        private System.Windows.Forms.Button buttonFetchGeneralData;
        private System.Windows.Forms.Label labelNumComments;
        private System.Windows.Forms.Label labelLastName;
        private System.Windows.Forms.Label labelFirstName;
        private System.Windows.Forms.Button buttonFetchMyPhotosFriendIsIn;
        private System.Windows.Forms.Button buttonFetchTaggedTogether;
        private System.Windows.Forms.Label labelNumLikes;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonFetchPhotosOfFriendIAmTaggedIn;
        private FlowLayoutPanelExtenderForFacebookFriends flowLayoutPanelExtenderForFacebookFriends;
    }
}
