   M S B A M L   `   `   `  ����  YouAreHeard0    *YouAreHeard.UserControls.DoctorTestControl   5      W SPresentationCore, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      .��5	      � $��
20,0,20,20q�6     � RowDefinitions  5
   
   �� 5      $
��Auto �6   �� 5      $��* �6   .+�5   
   �� $��Danh sách bệnh nhân��6   $��22(�5      $
��Bold"�5      $
��0,10q�5      �� 5   
   $��1��6   
������ $��0q�5      $��0,10,0,0q�5      ��5      �� *Appointments+ �� SelectedItem 5      �� *SelectedAppointment+��5      �� 5       �� 
TargetType" ��6   .�5      ��  �� Property � �� �� Value$ 0q�60   �� 5       � ��$	 0,5q�6/   �� 5        � ��$ 0q�68   �� 5!       � ��
 ���� 63   �� 5"       � ��$ Stretch=�6C   �� 5#       � ��$
 Bold"�63   5$      ��5'      �� 5(      .R�5)      ��  �� CornerRadius$ 30��6   
�������$��5q�5+       �� Padding$ 10q�5,      ���#DDD$��1q�5.       J� SnapsToDevicePixels$
 True��5/      ._�50      �  � ColumnDefinitions 51      �� 52   "   $��3* �63   �� 53   "   $��2* �63   �� 54   "   $��* �63   �� 55   "   $��* �63   �� 56   "   $��* �63   �� 57   "   $
��Auto �63   .+�5:      �� $��0��6M   $��Center=�6]   ��6(   �� *PatientProfile.Name+6]   �� 5;      $��1��6B   $��Center=�6R   ��6(   �� *
Location+6R   �� 5<      $��2��6F   $��Center=�6V   ��6(   �� *ScheduleTime+6V   �� 5=      $��3��6F   $��Center=�6V   ��6(   �� *ScheduleDate+6V   �� 5>      $��4��6E   $��Center=�6U   ��6(   �� *QueueNumber+6U   �� 5@      $��5��6%   $
 17.5��5A   %   ���#415AFA$��35��5C   %   $��Center=�5D   %   $��90��5E   %   $��10,0,0,0q�5F   %   ._�5G   "   �� $��Xét nghiệm��5H   %   
������ $��0q�5L   %   
�������$
��Bold"�5N   %   $��14(�5O   %   $
��10,5q�5P   %   	 � Cursor$
	 Hand��5Q   %   ��5I   %   �� *!DataContext.StartLabTestCommand+
 �� RelativeSource
 ��  �� AncestorType UserControl��5J   %   �� 5Q   %   5R      5S      5T      5U      5W      5X      5Y      