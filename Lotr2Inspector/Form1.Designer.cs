namespace Lotr2Inspector
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
			this.btGenerateTowns = new System.Windows.Forms.Button();
			this.btGeneratePlayers = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// btGenerateTowns
			// 
			this.btGenerateTowns.Location = new System.Drawing.Point(12, 12);
			this.btGenerateTowns.Name = "btGenerateTowns";
			this.btGenerateTowns.Size = new System.Drawing.Size(119, 23);
			this.btGenerateTowns.TabIndex = 0;
			this.btGenerateTowns.Text = "Generate CT towns";
			this.btGenerateTowns.UseVisualStyleBackColor = true;
			this.btGenerateTowns.Click += new System.EventHandler(this.btGenerateTowns_Click);
			// 
			// btGeneratePlayers
			// 
			this.btGeneratePlayers.Location = new System.Drawing.Point(13, 42);
			this.btGeneratePlayers.Name = "btGeneratePlayers";
			this.btGeneratePlayers.Size = new System.Drawing.Size(118, 23);
			this.btGeneratePlayers.TabIndex = 1;
			this.btGeneratePlayers.Text = "Generate CT players";
			this.btGeneratePlayers.UseVisualStyleBackColor = true;
			this.btGeneratePlayers.Click += new System.EventHandler(this.btGeneratePlayers_Click);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(146, 78);
			this.Controls.Add(this.btGeneratePlayers);
			this.Controls.Add(this.btGenerateTowns);
			this.Name = "Form1";
			this.Text = "Form1";
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button btGenerateTowns;
		private System.Windows.Forms.Button btGeneratePlayers;
	}
}