   M S B A M L   `   `   `  ����  YouAreHeard2    ,YouAreHeard.UserControls.AdminAccountControl   5      W SPresentationCore, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      .��5      � $��20, 0, 20, 20q�6     � RowDefinitions  5	   
   �� 5
      $	��500 �6   �� 5      $��* �6   .+�5   
   �� $��0��6   
������ $��0q�5      ��5       �� *	Doctors+��5      �� 5       �� 
TargetType" ��6   .�5      ��  �� Property � �� �� Value$ 0q�60   �� 5       � ��$	 0,5q�6/   �� 5       � ��$ 0q�68   �� 5       � ��
 ���� 63   �� 5       � ��$ Stretch=�6C   �� 5       � ��$
 Bold"�63   5      ��5      �� 5      .R�5      ��  �� CornerRadius$ 25��6   
�������$��5q�5       �� Padding$ 10q�5       ���#DDD$��1q�5"       J� SnapsToDevicePixels$
 True��5#      ._�5$      �  � ColumnDefinitions 5%      �� 5&   "   $��* �63   �� 5'   "   $��3* �63   �� 5(   "   $��* �63   �� 5)   "   $��* �63   �� 5*   "   $
��Auto �63   �� 5+   "   $
��Auto �63   .+�5/      �� $��0��6@   $��Center=�6P   ��6(   �� *UserId+6P   �� 50      $��1��6>   $��Center=�6N   ��6(   �� *Name+6N   �� 51      $��2��6@   $��Center=�6P   ��6(   �� *Gender+6P   �� 52      $��3��6B   $��Center=�6R   ��6(   �� *
RoleName+6R   �� 55      $��4��6'   $��Active��67   
���   �$
��Bold"�5:   '   $��14(�5;   '   $
��10,5q�5<   '   $��Center=�5=   '    � Cursor$
 Hand��5>   '   	 d� 	IsChecked	 56   '   �� *
IsActive+
 �� Mode$
 TwoWay=���57   '   �� *(&DataContext.ToggleAccountStatusCommand+ �� RelativeSource ��  �� AncestorType UserControl��58   '   �� *UserId+5>   '   �� 5?      $��5��6%   $
 17.5��5@   !   ���#28A745$��35��5B   !   $��Center=�5C   !   $	��120��5D   !   $��10,0,0,0q�5E   !   ._�5F   "   �� $��
Xem lịch��6)   
������ $��0q�5K   "   
�������$
��Bold"�5M   "   $��14(�5N   "   $
��10,5q�5O   "   $
 Hand��5P   "   ��5G   "   �� *!DataContext.ViewScheduleCommand+ ��  UserControl��5I   "   �� *UserId+5P   "   5Q      5R      5S      5T      5V      �� 5Y   
   $��1��6   $
 17.5��5Z      ���#28A745$��35��5\      $��Center=�5]      $	��120��5^      $��10,0,0,0q�5_      ._�5`      �� $��Tải lịch làm việc��6   
������ $��0q�5c      
�������$
��Bold"�5e      $��14(�5f      $
��10,5q�5g      $
 Hand��5h      ��5a      �� *#!DataContext.UploadScheduleCommand+ ��  UserControl5h      5i      5j      5k      