Jednotlivé programy jsou roztøízeny do složek podle èísla cvièení.
Program by mìlo být možné spustit z libovolného prostøedí po zkompilování C# pøekladaèem (csc), pøipadnì naimportování do Visual Studia
Po spuštìní každé z jednotlivých aplikací je dostupné jednoduché menu, které dovoluje zvolit šifru a její zpùsob encrypt-decrypt. Nìkdy je nutné zadat nejdøíve klíè, který je požadován od uživatele.

Pozn.
-Pøi implementaci cv2 jsem narazil na chybu, kdy pøíkaz Console.readLine je schopen naèíst do bufferu(najednou) pouze 255 bytu, pro otestování funkènosti øetìzce ze cvièení jsem požadovaný text pøidal pøímo do kódu aplikace.
-Implementace One Time Pad je provedena pomoci zadávaní v HEX soustavì, z dùvodu že po vyXORování dostávám zašifrovaný text v podobì, která neodpovídá ASCII znakùm.
