   M S B A M L   `   `   `  ����S  OProjurneyo_better_design, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullW0clr-namespace:Projurneyo_better_design.ViewModel"Projurneyo_better_design.ViewModel  5   	   W0clr-namespace:Projurneyo_better_design.Utilities"Projurneyo_better_design.Utilities  5   	   )    #Projurneyo_better_design.Prihlaseni   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ?vm0clr-namespace:Projurneyo_better_design.ViewModel     5   	   AMenu0clr-namespace:Projurneyo_better_design.Utilities     5   	   -   5          �Name$  ResponsiveWindow��5   	    � Title$ 
MainWindow��5	   	   $	��842��5
   	   $
��1350��5   	    � 
ResizeMode$ 	CanResize=�5   	    � WindowStartupLocation$ CenterScreen=�5   	   
������  � AllowsTransparency$
 True��5   	    � WindowStyle$
 None=�5   	   .��5      � -   5        $��Hlavni��5      $��0,0,0,0q�6   .+�5   
   �� ���#ffffff �� CornerRadius$ 10��5      � 5   
    � ColumnDefinitions 5      �� 5      $	��272 �6#   �� 5      $
��1078 �6#   �� 5       $��0* �6#    � RowDefinitions 5"      �� 5#      $	��45* �6    �� 5$      $
��797* �6    .+�5'      �� -   5        	 ��Name$	 control��5'      $��0,0,0,0q�6.   $��1��6?   $��1��6O   5(      �� 5)      ���#FF9843$ 0,0,0,10��5*      $��1��6-   ._�5,      �� $	��272��6   $��0,0,0,1q�6)   .+�5.      � $��41��6   � 5/      $	��159��6   .+�50      �� $��/UserIcon.png��6    $��
56,0,56,-1q�67   $
��Fill=�6K   51      �� 52      -   5        
 ��Name$
 LabelUsername��52       $��Username��53       $��29��60   $��0,20,0,0q�6<   $��center=�54       $��22(�6=    �� TextAlignment$ Center=�55       $	��272��67   $
��Bold"�56       �� 58      -   5        $
 LabelOrg��58       $��41��62   $��0,5,0,0q�6>   $��center=�59      $��20(�62   $ Center=�5:      $	��271��6,   � 5;      $��41��6   ,   &Projurneyo_better_design.Utilities.Btn  5=      -   5          Name$
 Btn1��5=      ,   &Projurneyo_better_design.Utilities.Btn   Click$ SwitchniNaProjekty_Click��6O      BtnStyle#��[  6-   $	��272��6p   .��5?      � .+�5@      �� $��Projekty��6(     
Text_Style#��[ 68   5A      5D        5E      -   5        $
 Btn4��5E      $! SwitchniNaLeaderboard_CLick��6O   #��[  6-   $	��272��6s   .��5F      � .+�5G      �� $��Žebříček��6(   #��[ 68   5H      5I        5J      -   5        $
 Btn2��5J      $! SwitchniNaNovyProjekt_CLick��6O   #��[  6-   $	��272��6s   .��5K      � .+�5L      �� $��Nový projekt��6(   #��[ 6<   5M      5N        5O      -	   5        $
 Btn3��5O      $ SwitchniNaTym_Click��6O   #��[  6-   $	��272��6k   .��5P      � .+�5Q      �� $
��Tým��6(   #��[ 63   5R      5S      5U      5Y      �� 5[      ���#3468C0$ 	10,10,0,0��6*   $��0��5\      $��2��6"   ._�5]      � .+�5^      �� -
   5         ��Name$ MinIcon��5^      $��
1310,8,0,7q�6-   $
��Left=�6A   $��30��6\   $��30��6h   $��/Krizek_h.png��6s   6�   �� 5_      -   5        $ ExitIcon��5_      $��
1266,8,0,7q�6.   $
��Left=�6B   $��30��6]   $��30��6i   $��/Minimalize_basic.png��6t   6�   �� 5`      $��Center=�6    $��Portál studenta��5a       $��94,0,1082,0q�5b       $��24(�65   
�������6C   �� 5c      -   5        $
 Back��5c      $��10,8,0,7q�6*   $
��Left=�6<   $��30��6W   $��30��6c   $��	/Back.png��6n   $
��Fill=�6�   6�   5e      5f      5h      5j      5k      