   M S B A M L   `   `   `  ����  Gallaxy Hospital&     Gallaxy_Hospital.DischargeMuster   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  DischargeMuster��5   	   $
��Auto��6!   $
��Auto��6/    � Icon$3 -/Gallaxy%20Hospital;component/Images/logo.png��6<    � 	Resources 5         	colHeader �� 
TargetType&   System.Windows.Controls.DataGrid �� Property  DatagridColumn �� Value=  7System.Windows.Controls.Primitives.DataGridColumnHeader��%B  &	        &	 |     �� 5   
   "  6#   .�5      ��  �@ ColumnHeaderStyle# �  62   �� 5       � ��$ 40��6'   5	      �� 5   
   "  6(   .�5      ��  � ��$ 40��6'   �� 5       � �� �	#FF1D637C6+   �� 5       � ��
 �����6+   �� 5       � ��$ 18(�6)   �� 5       � ��$ Times New Roman)�6+   �� 5       �@�Cursor$
 Hand��6'   �� 5       � ��$ 1q�60   �� 5       � ��
 �����6,   �� 5       � ��$ 40��6)   �� 5       � ��$ 2,2,2,2q�6(   5      5      .��5      � $	��900��6   $
��1200��6   ���	#FFFCEFEF.+�5   
   �� -   5        $��
rectangle3��5   9   $	��108��6   $��346,14,328,778q�6!   ���	#FF23A0A06K   �� 5   
   -   5        $��label23��5   �   $��Admission Muster��6   $��Sitka Heading)�6+   $��56(�6F   $
��Bold"�6T   ���	#FF1D637C$��86��6}   $��374,36,357,778q�6�   6�     5   
   -   5        $��	dataGrid1��5   �   #���   6      AutoGenerateColumns . $	��652��6R   $
��Left=�6_   $��190,214,0,0q�6z   $	��Top=�6�   $
��Auto��6�      AlternatingRowBackground �	#FFE2BFBF���	#FFFCEFEF$��2q�6     ClipboardCopyMode$ IncludeHeader=�6  	   MinColumnWidth$	 40Q�68  
   HorizontalGridLinesBrush
 �	#FF53A1D1   VerticalGridLinesBrush �	#FF53A1D1   HeadersVisibility$ Column=�6�     	RowHeight$ 30Q�6�  $��14(�6�  $	��730��6�  5!      �� 5#   
   -   5        $��bttnGoNamePres��5#   f   ���	#24B78492$��Go��6(   $��20(�65   $��40��6C   $��0,145,260,715q�6O   $��53��6|   $��Right=�6�   (  "System.Windows.Controls.DatePicker  5&   
   -   5        $��dtpckAdmissionTo��5&   8   $��44��6   $��0,148,319,708q�6!   $	��199��6P   $��Right=�6\     5'   
   -   5        $��dtpckAdmissionFrom��5'   8   $��44��6   $��390,145,0,711q�6!   $	��199��6R   $
��Left=�6^   �� 5(   
   -   5        $��label26��5(   P   $��To��6   $��24(�6   $��40��6+   $��616,149,524,711q�67   6P   �� 5)   
   -   5        $��label1��5)   R   $
��From��6   $��24(�6   $��40��6-   $��300,149,816,711q�69   $��84��6`   �� 5*   
   -	   5        $��button7��5*   `   ���	#24B78492$��	Dashboard��6(   $��40��6<   $��1020,14,30,846q�6H   $	��150��6o   6{   5+      5,      