   M S B A M L   `   `   `  ����  Gallaxy Hospital#    Gallaxy_Hospital.MedicineBill   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   -   5          � Title$  MedicineBill��5   	   $
��Auto��6   ���	#24B78492$��Stretch=�6B   $��Stretch=�6^    � WindowStartupLocation$ CenterScreen=�6�    � WindowState$ 	Maximized=�6�   $��Stretch=�6�   $��Stretch=�6�   $��24(�6   � 	Resources 5         	colHeader �� 
TargetType&   System.Windows.Controls.DataGrid �� Property  DatagridColumn �� Value=  7System.Windows.Controls.Primitives.DataGridColumnHeader��%B  &	        &	 |     �� 5   
   "  6#   .�5      ��  �@ ColumnHeaderStyle# �  62   �� 5	       � ��$ 40��6'   5
      �� 5   
   "  6(   .�5      ��  � ��$ 40��6'   �� 5       � �� �	#FF1D637C6+   �� 5       � ��
 �����6+   �� 5       � ��$ 18(�6)   �� 5       � ��$ Times New Roman)�6+   �� 5       �@�Cursor$
 Hand��6'   �� 5       � ��$ 1q�60   �� 5       � ��
 �����6,   �� 5       � ��$ 50��6)   �� 5       � ��$ 2,2,2,2q�6(   5      5      .��5      � $	��900��6   $
��1200��6   ���	#FFFCEFEF.+�5   
   �� -   5        $��
rectangle3��5   9   $	��108��6   $��394,26,343,766q�6!   ���	#FF23A0A06K   �� 5   
   -   5        $��label23��5   �   $��Prescription Bill��6   $��Sitka Heading)�6,   $��56(�6G   $
��Bold"�6U   ���	#FF1D637C$��86��6~   $��422,48,359,766q�6�   6�   �� 5   
   -   5        $��bttnPrescBillPrint��5   \   ���	#24B78492$��Print��6(   $��40��68   $��538,826,512,34q�6D   $	��150��6v   6�   �� 5    
   -   5        $��stackPanel1��5    S   $
��Auto��6   $
��Left=�6#   $��356,182,0,0q�6>   $	��Top=�6f   $	��469��6~   $	��300��6�   $	��600��6�   .+�5!        -   5        $��	dataGrid1��5!   e   #���   6      AutoGenerateColumns . $
��Auto��6W   $	��510��6v   $	��300��6�   $	��200��6�   $	��450��6�   �� 5"      -   5        $��stackPanel2��5"   %   $��86��6   $	��456��68    �� Orientation$ 
Horizontal=�6D   $��Right=�6]   .+�5#      �� -   5        $��label1��5#   ;   $��Total Amount��6   $��56��6/   $	��198��6I   $��Center=�6U   �� 5$      -	   5        $��txtTotalAmount��5$   &   $��56��6   $	��198��6<   $��Right=�6H   5%      5&      5'      5(      