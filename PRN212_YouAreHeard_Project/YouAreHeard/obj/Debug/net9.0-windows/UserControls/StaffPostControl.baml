   M S B A M L   `   `   `  ����F  BYouAreHeard, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullC&clr-namespace:YouAreHeard.UserControlsYouAreHeard.UserControls  5      /    )YouAreHeard.UserControls.StaffPostControl   5      W SPresentationCore, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      8local&clr-namespace:YouAreHeard.UserControls     5      .��5	      �� $
��Auto=�6   .��5
   
   � $��20q�6     � RowDefinitions  5      �� 5      $
��Auto �6    �� 5      $��* �6    �� 5      $
��Auto �6    .+�5      �� $��0��6   $��Center=�6&   $��0,0,0,20q�6C   .+�5      �� $
��1000��68   $
��auto��6E   $��0,0,0,50q�6S   ��6   �� *ImagePreview+6S   �� 5       �� CornerRadius$
 17.5��6   ���#415AFA$	��130��5      $��35��5      ._�5      �� $��Chọn ảnh��5       � Cursor$
 Hand��5      
������ $��0q�5      
�������$
��Bold"�5"      $��14(�5#      ��5!      �� *ChooseImageCommand+5#      5$      5%      �� 5(      $��1��6   .+�5*      � $	��0,5q�6   .+�5+      ��  �� RadiusX$ 10��6     �� RadiusY$ 10��6-   
���   �$	��1.4��6I    �� StrokeDashArray$	 4,2R�5,      ���	#FFDFDFDF62   �� 5-      $��10q�6!   .+�5.      �� $��Tiêu đề: ��6$   $
��Bold"�65   $��15(�6G   ���	#FF757575$��0,0,0,5q�6l   �� 5/      -   5         ��Name$ TitleBox��5/   9   
������ $��0q�6d   $��15(�50      $��50��6,    �� TextWrapping$
 Wrap=�68    �� AcceptsReturn$
 True��6L   ��5/   "   �� *Title+50   L   51      52      � 55      $	��0,5q�6   .+�56      �� $ 10��6    $ 10��6-   
���   �$	��1.4��6I   $	 4,2R�57      ���	#FFDFDFDF62   �� 58      $��10q�6!   .+�59      �� $��Nội dung: ��6$   $
��Bold"�66   $��15(�6H   ���	#FF757575$��0,0,0,5q�6m   �� 5:      -   5        $ 
DetailsBox��5:   :   
������ $��0q�6g   $��15(�5;      $	��200��6,   $
 Wrap=�69   $
 True��6M   ��5:   "   �� *Detail+5;   M   5<      5=      5>      �� 5A      $��2��6   $
 17.5��5B      ���#415AFA$	��120��5D      $��40��5E      $��0,20,0,0q�5F      $��Right=�5G      ._�5H      �� $��	Post Blog��5I      $
 Hand��5J      
������ $��0q�5L      
�������$
��Bold"�5O      $��15(�5P      ��5N      �� *UploadCommand+5P      5Q      5R      5S      5T      