   M S B A M L   `   `   `  ����  YouAreHeard7    1YouAreHeard.UserControls.DoctorAppointmentControl   5      W SPresentationCore, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      .��5      � $��20, 0, 20, 20q�6     � RowDefinitions  5	   
   �� 5
      $
��Auto �6   �� 5      $��* �6   .+�5   
   �� $��0��6   ���#415AFA �� CornerRadius$ 15��5       �� Padding$ 20q�5      $��0,0,0,15q�5       J� SnapsToDevicePixels$
 True��5      ._�5      �� .+�5      �� $��Cuộc hẹn sắp tới��6   $��20(�5      $
��Bold"�5      
�������$��0,0,0,10q�5      � 5       � ColumnDefinitions 5      �� 5      $��3* �6+   �� 5       $��2* �6+   �� 5!      $��* �6+   �� 5"      $��* �6+   �� 5#      $��* �6+   .+�5&      �� $��0��6U   
�������$��Center=�6x   $
��Bold"�6�   ��6    �� *%#NextAppointment.PatientProfile.Name+6�   �� 5'      $��1��6J   
�������$��Center=�6m   $
��Bold"�6�   ��6    �� *NextAppointment.Location+6�   �� 5(      $��2��6N   
�������$��Center=�6q   $
��Bold"�6�   ��6    �� *NextAppointment.ScheduleTime+6�   �� 5)      $��3��6N   
�������$��Center=�6q   $
��Bold"�6�   ��6    �� *NextAppointment.ScheduleDate+6�   �� 5*      $��4��6M   
�������$��Center=�6p   $
��Bold"�6�   ��6    �� *NextAppointment.QueueNumber+6�   5+      5,      5-      �� 50   
   $��1��6   $��0,10,0,0q�6    
������ $��0q�54      ��51      �� *Appointments+ �� SelectedItem 52      �� *SelectedAppointment+��55      �� 56       �� 
TargetType" ��6   .�57      ��  �� Property � �� �� Value$ 0q�60   �� 58       � ��$	 0,5q�6/   �� 59       � ��$ 0q�68   �� 5:       � ��
 ���� 63   �� 5;       � ��$ Stretch=�6C   �� 5<       � ��$
 Bold"�63   5=      ��5@      �� 5A      .R�5B      �� $ 30��6   
�������$��5q�5D      $ 10q�5E      ���#DDD$��1q�5G      $
 True��5H      ._�5I      �  5J      �� 5K   "   $��3* �63   �� 5L   "   $��2* �63   �� 5M   "   $��* �63   �� 5N   "   $��* �63   �� 5O   "   $��* �63   �� 5P   "   $
��Auto �63   .+�5U      �� $��0��6M   $��Center=�6]   ��6(   �� *PatientProfile.Name+6]   �� 5V      $��1��6B   $��Center=�6R   ��6(   �� *
Location+6R   �� 5W      $��2��6F   $��Center=�6V   ��6(   �� *ScheduleTime+6V   �� 5X      $��3��6F   $��Center=�6V   ��6(   �� *ScheduleDate+6V   �� 5Y      $��4��6E   $��Center=�6U   ��6(   �� *QueueNumber+6U   �� 5\      $��5��6%   $
 17.5��5]   !   ���#415AFA$��35��5_   !   $��Center=�5`   !   $��90��5a   !   $��10,0,0,0q�5b   !   ._�5c   "   �� $��
Chi tiết��5d   %   
������ $��0q�5h   %   
�������$
��Bold"�5j   %   $��14(�5k   %   $
��10,5q�5l   %   	 � Cursor$
	 Hand��5m   %   ��5e   %   �� * DataContext.ShowPatientCommand+
 �� RelativeSource
 ��  �� AncestorType UserControl��5f   %   �� 5m   %   5n      5o      5p      5q      5s      5t      5u      