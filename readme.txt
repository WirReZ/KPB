Jednotliv� programy jsou rozt��zeny do slo�ek podle ��sla cvi�en�.
Program by m�lo b�t mo�n� spustit z libovoln�ho prost�ed� po zkompilov�n� C# p�eklada�em (csc), p�ipadn� naimportov�n� do Visual Studia
Po spu�t�n� ka�d� z jednotliv�ch aplikac� je dostupn� jednoduch� menu, kter� dovoluje zvolit �ifru a jej� zp�sob encrypt-decrypt. N�kdy je nutn� zadat nejd��ve kl��, kter� je po�adov�n od u�ivatele.

Pozn.
-P�i implementaci cv2 jsem narazil na chybu, kdy p��kaz Console.readLine je schopen na��st do bufferu(najednou) pouze 255 bytu, pro otestov�n� funk�nosti �et�zce ze cvi�en� jsem po�adovan� text p�idal p��mo do k�du aplikace.
-Implementace One Time Pad je provedena pomoci zad�van� v HEX soustav�, z d�vodu �e po vyXORov�n� dost�v�m za�ifrovan� text v podob�, kter� neodpov�d� ASCII znak�m.
