   M S B A M L   `   `   `  ���� S  OProjurneyo_better_design, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullW0clr-namespace:Projurneyo_better_design.ViewModel"Projurneyo_better_design.ViewModel  W0clr-namespace:Projurneyo_better_design.Utilities"Projurneyo_better_design.Utilities  )    #Projurneyo_better_design.Prihlaseni   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     ?vm0clr-namespace:Projurneyo_better_design.ViewModel     AMenu0clr-namespace:Projurneyo_better_design.Utilities     -     �Name$  ResponsiveWindow�� � Title$ 
MainWindow��$	��842��$
��1350�� � 
ResizeMode$ 	CanResize=� � WindowStartupLocation$ CenterScreen=�
������  � AllowsTransparency$
 True�� � WindowStyle$
 None=�.��� -   $��Hlavni��$��0,0,0,0q�.+��� ���#ffffff �� CornerRadius$ 10���  � ColumnDefinitions �� $	��272 ��� $
��1078 ��� $��0* � � RowDefinitions �� $	��45* ��� $
��797* �.+��� -   	 ��Name$	 control��$��0,0,0,0q�$��1��$��1���� ���#FF9843$ 0,0,0,10��$��1��._��� $	��272��$��0,0,0,1q�.+�� $��41��� $	��159��.+��� $��/UserIcon.png��$��
56,0,56,-1q�$
��Fill=��� -   
 ��Name$
 LabelUsername��$��Username��$��29��$��0,20,0,0q�$��center=�$��22(� �� TextAlignment$ Center=�$	��272��$
��Bold"��� -   $
 LabelOrg��$��41��$��0,5,0,0q�$��center=�$��20(�$ Center=�$	��271��� $��41��,   &Projurneyo_better_design.Utilities.Btn  -     Name$
 Btn1��,   &Projurneyo_better_design.Utilities.Btn   Click$ SwitchniNaProjekty_Click��   BtnStyle#��[  $	��272��.��� .+��� $��Projekty��  
Text_Style#��[   -   $
 Btn4��$! SwitchniNaLeaderboard_CLick��#��[  $	��272��.��� .+��� $��Žebříček��#��[   -   $
 Btn2��$! SwitchniNaNovyProjekt_CLick��#��[  $	��272��.��� .+��� $��Nový projekt��#��[   -	   $
 Btn3��$ SwitchniNaTym_Click��#��[  $	��272��.��� .+��� $
��Tým��#��[ �� ���#3468C0$ 	10,10,0,0��$��0��$��2��._�� .+��� -
    ��Name$ MinIcon��$��
1310,8,0,7q�$
��Left=�$��30��$��30��$��/Krizek_h.png���� -   $ ExitIcon��$��
1266,8,0,7q�$
��Left=�$��30��$��30��$��/Minimalize_basic.png���� $��Center=�$��Portál studenta��$��94,0,1082,0q�$��24(�
��������� -   $
 Back��$��10,8,0,7q�$
��Left=�$��30��$��30��$��	/Back.png��$
��Fill=�