   M S B A M L   `   `   `  ���� F  BChronoSaver, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:ChronoSaverChronoSaver  M+clr-namespace:ChronoSaver.View.UserControlsChronoSaver.View.UserControls      ChronoSaver.MainWindow   W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     +localclr-namespace:ChronoSaver     DuserControls+clr-namespace:ChronoSaver.View.UserControls       � 
ResizeMode$  CanMinimize=� � Title$ 
MainWindow��$	��450��$	��800�� � 	Resources  �� 
TargetType �� 	Resources �� Property �� Value   SlotRadioButton �� 
TargetType ��Name	 �� CornerRadius
 �� Triggers P� Property P� Value �� 
TargetName  StackPanelStyle  SlotText  	SlotImage��%�  '��       &	  �     &	     &	 n    &	 �    '�� C    �� " �� ���� '��       " ��.���  �@��CornerRadius$ 10����  � ��$ 5q���  � ��$ Stretch=���  � ��$ Center=���  � ��$
 Auto����  � ��$	 140���� " 	�.���  � �� �� " 	�.R�� .+��� $ Slot_��
���   �$��2q����#E5FFF7$	 10��._��� $��Center=�$��Center=�
 P�  �@d�	IsChecked$
 TrueY�. ��� $ Slot_�� � ��
 �i���� $ Slot_�� � ��$ 4q���  � ��$	 256����  � ��$	 180����  � ��$ 3���� " ��.���  �@��Orientation$ Vertical=���  � ��$ Center=���  � ��$	 Top=��� " ��.���  � ��$ 22(���  � ��$ Center=���  � ��$ Center=��� " �� ���� '��       " ��.���  �@��CornerRadius$ 10��.���  � ��$	 256����  � ��$	 140���� " ��.���  �@��CornerRadius$ 10��.���  � RowDefinitions �� �� �� �� �� �� ��  � ColumnDefinitions �� �� �� .+�0   *ChronoSaver.View.UserControls.ChronoButton  -     Name$ BtnSave��$��5��$��1��   ContentText$
 Save��   Color
 �����  -   $ BtnLoad��$��5��$��0��$
 Load�� �#C9D8E9  -   $ 	BtnDelete��$��5��$��2��$ Delete��
 ��p��	� -    	� 	GroupName$ Slots��#��[  $��0��$��1��$��4�� d� 	IsChecked �� *SlotArray[0]+ �� Mode$ TwoWay=�.���� #��[ .+��� -    ��Name$ 
SlotImage1��#��[ �� $��Slot 1��#��[ 	� -   $ Slots��#��[  $��1��$��1��$��4�� �� *SlotArray[1]+$ TwoWay=�.���� #��[ .+��� -   $ 
SlotImage2��#��[ �� $��Slot 2��#��[ 	� -   $ Slots��#��[  $��2��$��1��$��4�� �� *SlotArray[2]+$ TwoWay=�.���� #��[ .+��� -	   $ 
SlotImage3��#��[ �� $��Slot 3��#��[ �� $��0��$��0��$��3��$��Center=�$��Center=�$��20(����� *Status+