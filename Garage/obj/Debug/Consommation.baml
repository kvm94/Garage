   M S B A M L   `   `   `  ����A  =Garage, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:GarageGarage  5   	       Garage.Consommation   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   &localclr-namespace:Garage     5   	     � Title$  Consommation��5   	   $��289.195��6   $	��300��6/    � 
ResizeMode$ NoResize=�6;    � WindowStartupLocation$ CenterScreen=�6Q   .��5	      � .+�5
   
   �� -   5         ��Name$ 
tabControl��5
      $
��Left=�6)   $	��259��6D   $	��Top=�6Q   $	��292��6i   $��0,0,0,-1q�6u   .@�5      �� $��Actuel��6   $��	0,0,-4,-2q�6&   .��5      � ���	#FFE5E5E5$��0,-1,0,0q�6.   .+�5      �� -   5         ��Name$ label_titre��5      $"��Consommation pour le plein :��61   $
��Left=�6X   $��	55,17,0,0q�6s   $	��Top=�6�   $
��Bold"�6�   �� 5      -   5        $ label_litre��5      $��Litres :��61   $
��Left=�6D   $��	35,56,0,0q�6_   $	��Top=�6r   �� 5      -   5        $ label_Km��5      $��Km parcourus :��6.   $
��Left=�6G   $��	35,87,0,0q�6b   $	��Top=�6u   �� 5      -   5        $ 
label_Cout��5      $��Cout (€) :��60   $
��Left=�6E   $��
35,118,0,0q�6`   $	��Top=�6t   �� 5      -   5         ��Name$ button_Retour��5      $��Retour��64   $
��Left=�6E   $��
35,188,0,0q�6`   $	��Top=�6t   $��75��6�   6�   �� 5      -   5        $ button_Calculer��5      $��Calculer��66   $
��Left=�6I   $��178,188,0,0q�6d   $	��Top=�6y   $��75��6�   6�   �� 5      -   5         ��Name$ textBox_Litre��5      $
��Left=�65   $��23��6P   $��
150,60,0,0q�6\    �� TextWrapping$
 Wrap=�6p   $	��Top=�6�   $	��120��6�   �� 5      -	   5        $ 
textBox_Km��5      $
��Left=�62   $��23��6M   $��
150,91,0,0q�6Y   $
 Wrap=�6m   $	��Top=�6�   $	��120��6�   �� 5      -
   5        $ textBox_Cout��5      $
��Left=�64   $��23��6O   $��150,122,0,0q�6[   $
 Wrap=�6p   $	��Top=�6�   $	��120��6�   5      5      �� 5      -   5         ��Name$ tabItem_Moyenne��5      $��Moyenne��6/   .��5      � ���	#FFE5E5E5$��	0,1,-1,-1q�6.   	 � ColumnDefinitions	 5      �� 5      $
��159* �6+   �� 5      $
��128* �6+   .+�5      �� -   5        $ button_Retour_Copy��5      $��Retour��69   $
��Left=�6J   $��
33,188,0,0q�6e   $	��Top=�6y   $��75��6�   6�   �� 5      -   5        $ label_titre_Copy1��5      $��Consommation moyenne :��67   $
��Left=�6X   $��	62,19,0,0q�6s   $	��Top=�6�   $
��Bold"�6�   $��2��6�   �� 5       -   5        $ label_litre_km��5       $��Litres/100Km :��64   $
��Left=�6M   $��	26,78,0,0q�6h   $	��Top=�6{   �� 5!      -   5        $ label_Cout_Km��5!      $��Cout(€)/100Km :��63   $
��Left=�6M   $��
26,109,0,0q�6h   $	��Top=�6|   �� 5"      -   5        
 ��Name$
 textBlock_Litre_Km��5"       $
��Left=�6<   $��12.11,83,0,0q�6W   $
��Wrap=�6m   $��	Undefined��6�   $	��Top=�6�   $��1��6�   �� 5#      -   5        $
 textBlock_LCout_Km��5#       $
��Left=�6<   $��12.11,114,0,0q�6W   $
��Wrap=�6n   $��	Undefined��6�   $	��Top=�6�   $��1��6�   5$      5%      �� 5&      -   5        $ tabItem_DernierPlein��5&      $��Dernier plein��64   .��5'      � ���	#FFE5E5E5$��0,0,-1,0q�6.   .+�5(      �� -   5        $ label_titre_Copy��5(      $*��$Consommation pour le dernier plein :��66   $
��Left=�6e   $��	37,18,0,0q�6�   $	��Top=�6�   $
��Bold"�6�   �� 5)      -   5        $ button_Retour_Copy1��5)      $��Retour��6:   $
��Left=�6K   $��
25,191,0,0q�6f   $	��Top=�6z   $��75��6�   6�   �� 5*      -   5        $ label_litre_km_Copy��5*      $��Litres/100Km :��69   $
��Left=�6R   $��	39,84,0,0q�6m   $	��Top=�6�   �� 5+      -   5        $ label_Cout_Km_Copy��5+      $��Cout(€)/100Km :��68   $
��Left=�6R   $��
39,115,0,0q�6m   $	��Top=�6�   �� 5,      -   5        $
 textBlock_Litre_Km_Copy��5,       $
��Left=�6A   $��
184,89,0,0q�6\   $
��Wrap=�6p   $��	Undefined��6�   $	��Top=�6�   �� 5-      -   5        $
 textBlock_LCout_Km_Copy��5-       $
��Left=�6A   $��184,120,0,0q�6\   $
��Wrap=�6q   $��	Undefined��6�   $	��Top=�6�   5.      5/      50      51      52      