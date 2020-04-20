﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestEntityFramework
{
    public partial class PersonForm : Form
    {
        PersonFormContext personFormContext;

        public PersonForm(PersonFormContext personFormContext)
        {
            this.personFormContext = personFormContext;
            
            InitializeComponent();

            dataGridView1.DataSource = personFormContext.Persons;
        }
    }
}
