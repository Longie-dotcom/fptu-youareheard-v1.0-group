   M S B A M L   `   `   `  ����F  BYouAreHeard, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:YouAreHeard.ViewsYouAreHeard.Views  5   	   1    +YouAreHeard.Views.AdminDoctorScheduleDetail   5   	   W SPresentationCore, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   1localclr-namespace:YouAreHeard.Views     5   	     � WindowStartupLocation$  CenterScreen=�5   	    � Title$! Lịch làm việc bác sĩ��5	   	   $	��450��6&   $	��800��63   .��5
      � $��10q�6   .+�5   
   &   System.Windows.Controls.DataGrid     AutoGenerateColumns$ False��5         
IsReadOnly$
 True��5         HeadersVisibility$ Column=�5         CanUserAddRows$ False��5      ��5      �� *DoctorSchedules+   Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5         FontSize$ 20Q�6%      
FontWeight$
 Bold"�63   ,  &System.Windows.Controls.DataGridColumn	   Width5  /System.Windows.Controls.DataGridLengthConverter$	 * 6E   
   Header$
 Phòng��6O   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6^   �� *
Location+  5      $ 20Q�6%   $
 Bold"�63   $	 * 6E   $
 Bắt đầu��6O    6`   �� *	StartTime+  5      $ 20Q�6%   $
 Bold"�63   $	 * 6E   $
 Kết thúc��6O    6a   �� *	EndTime+  5      $ 20Q�6%   $
 Bold"�63   $	 * 6E   $
 Ngày��6O    6]   �� *Date+ �� StringFormat$ d��5      5      5      