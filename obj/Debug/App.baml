   M S B A M L   `   `   `  ����B  >RAM_CMS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:RAM_CMSRAM_CMS  5          RAM_CMS.App   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      'localclr-namespace:RAM_CMS     5        �� 	Resources  5       	  White �� Color  Window_Background 
 Middle  Highlited_Background  Highlight_color_less  Highlight_color  MouseEnterAnimation �� TargetProperty	 W� To g� Duration  MouseLeaveAnimation  RoundedButtonStyle �� 
TargetType �� Property �� Value �� 
TargetType	 �� CornerRadius
 �� Triggers :� RoutedEvent��%�  &	        &	 $     &	 E     &	 f     &	 �     &	 �     &	 �     &	 �    &	 �    7  7  �� 5   
   $ 
#FFFDFFFF ��67   �� 5   
   $ #DDD5D0��67   �� 5	   
   $ #CFC0BD��67   �� 5
   
   $ #B8B8AA��67   �� 5   
   $ #7F9183��67   �� 5   
   $ 	#FF586F6B��67   �� 5   
   .��5      W� $6 0(Button.RenderTransform).(ScaleTransform.ScaleX)�6   $ 1.075X�5      $ 0:0:0.2D�6)   W� 5      $6 0(Button.RenderTransform).(ScaleTransform.ScaleY)�6   $ 1.075X�5      $ 0:0:0.2D�6)   5      �� 5   
   .��5      W� $6 0(Button.RenderTransform).(ScaleTransform.ScaleX)�6   $ 1X�5      $ 0:0:0.2D�6%   W� 5      $6 0(Button.RenderTransform).(ScaleTransform.ScaleY)�6   $ 1X�5      $ 0:0:0.2D�6%   5      �� 5   
   " ��6+   .�5      ��  � �� 5      �� 5      " ��6&   .R�5      �� #��z��6!   #��z��5    !   #��z��5!   !   $	 10��5"   !   ._�5#      �� $��Center=�6/   $��Center=�6L   5$      5%      5'      
 5)      :� 5*      $ 
MouseEnter��6   .[�5+      �� 8��  6&   5,      :� 5-      $ 
MouseLeave��6   .[�5.      �� 8�� 6&   5/      51      54      55      