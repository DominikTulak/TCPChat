   M S B A M L   `   `   `  ����B  >TCPTest, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:TCPTestTCPTest  5   	       TCPTest.TCPServer   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:TCPTest     5   	     � Title$  	TCPServer��5   	   $	��450��6   $	��800��6(   .��5	      � .+�5
   
   �� $��
IP Adresa:��6   $
��Left=�6%   $��	44,32,0,0q�6@   $	��Top=�6S   �� 5   
   $��Port:��6   $
��Left=�6    $��	44,61,0,0q�6;   $	��Top=�6N   �� 5   
   -   5        $��	Vytvořit��5      $
��Left=�6$   $��
170,92,0,0q�6?   $	��Top=�6S   $��76��6k   6v   �� 5   
   -   5         ��Name$ 	OutputBox��5      $
��Left=�6%   $	��249��6@   $��
10,132,0,0q�6M    �� TextWrapping$
 Wrap=�6a   $	��Top=�6u   $	��772��6�   �� 5   
   -   5        $ InputBox��5      $
��Left=�6$   $��23��6?   $��
10,386,0,0q�6K   $
 Wrap=�6_   $	��Top=�6s   $	��772��6�   6�   �� 5   
   -   5        $ IPBox��5       �� 
IsReadOnly . $
��Left=�63   $��23��6N   $��
126,36,0,0q�6Z   $
 Wrap=�6n   $��	127.0.0.1��6�   $	��Top=�6�   $	��120��6�   �� 5   
   -   5        $ PortBox��5      $
��Left=�6#   $��23��6>   $��
126,64,0,0q�6J   $
 Wrap=�6^   $��22222��6r   $	��Top=�6   $	��120��6�   5      5      