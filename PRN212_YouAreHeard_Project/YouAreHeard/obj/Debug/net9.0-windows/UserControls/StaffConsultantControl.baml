   M S B A M L   `   `   `  ����F  BYouAreHeard, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullC&clr-namespace:YouAreHeard.UserControlsYouAreHeard.UserControls  5      5    /YouAreHeard.UserControls.StaffConsultantControl   5      W SPresentationCore, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      8local&clr-namespace:YouAreHeard.UserControls     5      .��5	      � .+�5
   
   � $��20, 0, 20, 20q�6     � RowDefinitions  5      �� 5      $
��Auto �6    �� 5      $��* �6    .+�5      �� $��0��6   ���#415AFA �� CornerRadius$ 15��5       �� Padding$ 20q�5      $��0,0,0,15q�5       J� SnapsToDevicePixels$
 True��5      ._�5      �� .+�5      �� $��Cuộc hẹn sắp tới��6    $��20(�5      $
��Bold"�5      
�������$��0,0,0,10q�5      � 5       � ColumnDefinitions 5       �� 5!      $��3* �6/   �� 5"      $��2* �6/   �� 5#      $��* �6/   �� 5$      $��* �6/   �� 5%      $��* �6/   .+�5(      �� $��0��6Y   
�������$��Center=�6|   $
��Bold"�6�   ��6$   �� *%#NextAppointment.PatientProfile.Name+6�   �� 5)      $��1��6N   
�������$��Center=�6q   $
��Bold"�6�   ��6$   �� *NextAppointment.Location+6�   �� 5*      $��2��6R   
�������$��Center=�6u   $
��Bold"�6�   ��6$   �� *NextAppointment.ScheduleTime+6�   �� 5+      $��3��6R   
�������$��Center=�6u   $
��Bold"�6�   ��6$   �� *NextAppointment.ScheduleDate+6�   �� 5,      $��4��6Q   
�������$��Center=�6t   $
��Bold"�6�   ��6$   �� *NextAppointment.QueueNumber+6�   5-      5.      5/      �� 52      $��1��6   $��0,10,0,0q�6$   
������ $��0q�56      ��53      �� *Appointments+ �� SelectedItem 54      �� *SelectedAppointment+��57      �� 58       �� 
TargetType" ��6   .�59      ��  �� Property � �� �� Value$ 0q�64   �� 5:       � ��$	 0,5q�63   �� 5;       � ��$ 0q�6<   �� 5<       � ��
 ���� 67   �� 5=       � ��$ Stretch=�6G   �� 5>       � ��$
 Bold"�67   5?      ��5B      �� 5C      .R�5D      �� $ 30��6!   
�������$��5q�5F      $ 10q�5G      ���#DDD$��1q�5I      $
 True��5J      ._�5K      �  5L   "   �� 5M   &   $��3* �67   �� 5N   &   $��2* �67   �� 5O   &   $��* �67   �� 5P   &   $��* �67   �� 5Q   &   $��* �67   �� 5R   &   $
��Auto �67   .+�5W   "   �� $��0��6Q   $��Center=�6a   ��6,   �� *PatientProfile.Name+6a   �� 5X   "   $��1��6F   $��Center=�6V   ��6,   �� *
Location+6V   �� 5Y   "   $��2��6J   $��Center=�6Z   ��6,   �� *ScheduleTime+6Z   �� 5Z   "   $��3��6J   $��Center=�6Z   ��6,   �� *ScheduleDate+6Z   �� 5[   "   $��4��6I   $��Center=�6Y   ��6,   �� *QueueNumber+6Y   �� 5^   "   $��5��6)   $
 17.5��5_   !   ���#415AFA$��35��5a   !   $��Center=�5b   !   $��90��5c   !   $��10,0,0,0q�5d   !   ._�5e   &   �� $��
Chi tiết��5f   %   
������ $��0q�5j   %   
�������$
��Bold"�5l   %   $��14(�5m   %   $
��10,5q�5n   %   	 � Cursor$
	 Hand��5o   %   ��5g   %   �� * DataContext.ShowPatientCommand+
 �� RelativeSource
 ��  �� AncestorType UserControl��5h   %   �� 5o   %   5p   #   5q      5r      5s      5u      5v      5w      5x      