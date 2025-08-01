﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using YouAreHeard.ViewModels;

namespace YouAreHeard.UserControls
{
    /// <summary>
    /// Interaction logic for DoctorTreatmentControl.xaml
    /// </summary>
    public partial class DoctorTreatmentControl : UserControl
    {
        public DoctorTreatmentControl(int doctorId)
        {
            InitializeComponent();
            DataContext = new DoctorMedicalViewModel(doctorId);
        }
    }
}
