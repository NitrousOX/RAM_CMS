   M S B A M L   `   `   `  ����B  >RAM_CMS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:RAM_CMS.WindowsRAM_CMS.Windows  5   	   "    RAM_CMS.Windows.ChangeWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   /localclr-namespace:RAM_CMS.Windows     5   	   X TXceed.Wpf.Toolkit, Version=4.6.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f44xctk)http://schemas.xceed.com/wpf/xaml/toolkit  5   	   -   5          � Title$  ChangeWindow��5	   	    � WindowStyle$
 None=�5
   	    � AllowsTransparency . 
������  � WindowStartupLocation$ CenterScreen=�5   	    � SizeToContent$ WidthAndHeight=�5   	   .��5      �� $	��500��6   $	��500��6   .+�5   
   F� -   5        $��ViewPath��5         Window_Background#���   6   
���   ���5      B� 5      .��5      E�  E� 
StartPoint$	 0,0&�6!   .��5      ��  �� Point$ 0,500&�6&   �� 5      $ 500,500&�6&   �� 5      $ 500,0&�6&   5      5      5      � 5   
   $	��500��6   $	��500��6    � RowDefinitions 5      �� 5      �� 5      .+�5      �� -   5        $��0��5      $��X��6"   $��Right=�6.   $	��Top=�6J   $��42��6b   $��38��6m     Highlight_color#���  6y   $��3��6�    	 White#���  6�   |�.  $��20(�6  �� 5       -   5         ��Name$ RTF_VIEW��5       $��1��6,   |�.  	 J� IsHitTestVisible	 .    Highlight_color_less#���  6d   #���  6�   . �5!      /� .T�5"      J� .*�6    5#      5$      5%      �� 5&      -   5        
 ��Name$
 img_preview��5&      $	��150��6)    �� Left$ 34��66   
 �� Top$ 48��6G   $	��150��6W   $��27,50,323,50q�6c   �� 5'      -   5         ��Name$ 
Label_name��5'      $
��Name��6(   $
��Left=�67   $��
250,98,0,0q�6R   $	��Top=�6f   $��36��6~   $��64��6�   #���  6�   $��20(�6�   �� 5(      -   5        $ 	Labe_size��5(      $
��Size��6'   $
��Left=�66   $��269,142,0,0q�6Q   $	��Top=�6f   $��38��6~   $��45��6�   #���  6�   $��20(�6�   �� 5)      -   5        $ 	Labe_Date��5)      $��
Date added��6'   $
��Left=�6<   $��202,183,0,0q�6W   $	��Top=�6l   $��38��6�   $	��112��6�   #���  6�   $��20(�6�   �� 5*      -	   5         ��Name$ TextBox_Name��5*       �� TextWrapping$
 Wrap=�6,   $��321,98,21,116q�6@   #���   6W   #���  6�   $��18(�6�   $��0��6�   |�.  	 .  6�   �� 5+      -
   5        $ TextBox_Date��5+      $
 Wrap=�6,   $��321,185,21,29q�6@   #���   6W   #���  6�   $��18(�6�   $��0��6�   |�.  	 .  6�   �� 5,      -   5        $ TextBox_Size��5,      $
 Wrap=�6,   $��321,142,21,72q�6@   #���   6W   #���  6�   $��18(�6�   $��0��6�   |�.  	 .  6�   5-      5.      5/      