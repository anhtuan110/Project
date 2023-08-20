﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RestaurentManager
{
	public partial class fTableManager : Form
	{
		public fTableManager()
		{
			InitializeComponent();
		}
		private void adminToolStripMenuItem_Click(object sender, EventArgs e)
		{
			fAdmin fAdmin = new fAdmin();
			fAdmin.ShowDialog();
		}

		private void PersonalInfoToolStripMenuItem_Click_1(object sender, EventArgs e)
		{
			fAccountProfile fAccountProfile = new fAccountProfile();
			fAccountProfile.ShowDialog();

		}

		private void LogOutToolStripMenuItem_Click_1(object sender, EventArgs e)
		{
			this.Close();
		}

	}
}