   M S B A M L   `   `   `  ����B  >onthi05, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:onthi05onthi05  5   	       onthi05.MainWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:onthi05     5   	     � Title$  
MainWindow��5   	   $	��498��6   $	��800��6)   .��5	      � -   5         � 	Resources 5
   
      text �� 
TargetType �� Property �� Value=  7System.Windows.Controls.Primitives.DataGridColumnHeader  templatebtn �� 
TargetType �� CornerRadius��%  &	        '  �     '�� �     &	 K    �� 5      " ��6!   .�5      ��  � ��$ Times New Roman)�6/   6I   �� 5       � ��
 ��  �6>   5      �� 5      "  6   .�5      ��  � ��$
 Bold"�6/   6>   �� 5       � ��$ Center=�6?   6P   5      �� 5      " ��6   .�5      ��  � ��$
 Bold"�6/   6>   5      �� 5      " ��62   .R�5      � .+�5      �� $ 50��6   
�������6C   �� 5      $��Center=�6'   6F   5      5      5      .+�5   
   �� $��Mã bệnh nhân��6   $
��Left=�6'   $��	56,34,0,0q�6B   $	��Top=�6U   �� 5   
   $��	Họ tên��6   $
��Left=�6!   $��	56,79,0,0q�6<   $	��Top=�6O   �� 5   
   $��Số ngày nằm viện��6   $
��Left=�6+   $��
56,124,0,0q�6F   $	��Top=�6Z   �� 5    
   $��
Khoa khám��6   $
��Left=�6$   $��
56,168,0,0q�6?   $	��Top=�6S   �� 5!   
   -   5         ��Name$ txtmabenhnhan��5!   0   #��[  6   $
��Left=�6G   $��
227,34,0,0q�6b    �� TextWrapping$
 Wrap=�6v   $	��Top=�6�   $	��173��6�   6�   �� 5"   
   -   5        $ txthoten��5"   0   #��[  6   $
��Left=�6B   $��
227,79,0,0q�6]   $
 Wrap=�6q   $�� ��6�   $	��Top=�6�   $	��173��6�   �� 5#   
   -   5        $ txtsongaynamvien��5#   0   #��[  6   $
��Left=�6J   $��227,132,0,0q�6e   $
 Wrap=�6z   $�� ��6�   $	��Top=�6�   $	��173��6�   �� 5$   
   -   5        	 ��Name$	 cbokhoa��5$      $
��Left=�6$   $��227,178,0,0q�6?   $	��Top=�6T   $	��173��6l   &   System.Windows.Controls.DataGrid  5%   
   -   5        
  Name$
 dgvbenhnhan��5%      $��
0,217,0,43q�6(      AutoGenerateColumns$ False��6l      CanUserAddRows$ False��6�      Columns 5&      0  *System.Windows.Controls.DataGridTextColumn  5'      ,  &System.Windows.Controls.DataGridColumn   Header$ Mã bệnh nhân��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6T   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6;   �� *MaBn+6`     5(      $ 	Họ tên��6%   $ * 6O    65   �� *HoTen+6[     5)      $ 
Khoa khám��6%   $ * 6S    68   �� *MaKhoa+6_     5*      $ Số ngày nằm viện��6%   $ * 6a    6?   �� *SoNgayNamVien+6m     5+      $ Viện phí��6%   $ * 6S    67   �� *	VienPhi+6_   5-      �� 5.   
   -   5         ��Name$ btnthem��5.      $��Thêm��6#   $
��Left=�62   $��254,444,0,0q�6M   $	��Top=�6b   $��60��6z   $��34��6�   6�   �� 5/   
   -   5        $ btntim��5/      $
��Tìm��6"   $
��Left=�60   $��433,444,0,0q�6K   $	��Top=�6`   $��60��6x   $��34��6�   6�   51      52      