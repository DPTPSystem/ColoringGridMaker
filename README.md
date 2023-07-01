# Coloring Grid Maker 2023
* DPTP SYSTEM - Coloring Grid Maker
* Dátum: 2023.06.27.
* #C, Net v4.7.2

![DPTP System](https://github.com/DPTPSystem/ColoringGridMaker/blob/master/images/cgm4.JPG "DPTP System")

# Folyamat
* 2023.06.27. Prpjekt kezdése (v0.1)
* * Alap Form (GIU) kialakítása
* * Fájl dialog és feldolgozás
* * Kép betöltése
* * Kép másolása
* 2023.06.28. Fejlesztés 1 (v0.6)
* * Form (GUI) kiegészítése
* * Kép átlátszóságának csússzkával történő állítása
* * Kép pixelenkénti nagyításának állítása
* * Képre írt számok méretének állítása
* * Kép mentése
* * Kép méreteinek kiírása a GUI felületre
* 2023.06.29. Fejlesztés 2 (v0.7)
* * GUI kiegészítés, Grid, Color Palette
* * Opcionális rácsozás
* * Opcionális szinpalette integráció
* * Képek külömböző exportálása (Normal számkódos, Külön színpaletta, kombinált - kettőt az egyben)
* * Rács optimalizálása
* 2023.07.01. Fejlesztés 3 (v1.0)
* * Fáj neve tartalmazza az eredeti fájl nevét
* * Használható v1.0 verzió elkészült.

# Mi is ez?
Egy program, amely egy képet színkód alapján detektál és rácsos szerkezetbe rendezve tervet készít és ezzel segít, egy amolyan kifestős festők 
gyakorlásában, illetve amatőröknek biztosít segítséget, hogy könnyebben tudjanak szépet alkotni.

# Miért
Ötletként merült fel, hogy jól nézne ki, ha bizonyos pixel képeket tempera vagy más vízbázisú festékkel alkotnánk újra, de ehhez tehetség is
kellene, amely nem feltétlen áll mindenki rendelkezésére. Ennek okán kezdtem el fejleszteni egy programot, amely segít abban, hogy a megfelelő
színt a megfelelő helyre pozicionálva festhetünk és ezzel érhessünk el sikerélményeket. Másrészt pedig szebben mutat a falon egy saját festmény, 
mint egy géppel kinyomtatott digitális kép.

# Elképzelés
A programba egy előre elkészített képet töltünk be. Az előkészítés mindig annak függvénye lesz, hogy hány szinnel akarunk dolgozni és mekkora 
felbontásba. Erre azért lesz szükség, mert a kép adatfeldolgozásánál könnyeben tudjuk a színeket azonosítani. Továbbá majd beállítható lesz,
hogy az adott kép mekkora felbontásban és milyen rácsmérettel rendelkezzen. Generáláskor a program legenerálja az adott rácsszerkezetet és 
színpalettát, amelyet számokkal is ellát, amely számok majd az aktuális pozíciót is mutatják a rácsszerkezeten belül. Kb. ez az elképzelés, 
hogy a megvalósítás közben milyen egyéb változások kerülnek a programban majd a végén derül ki.

![DPTP System](https://github.com/DPTPSystem/ColoringGridMaker/blob/master/images/repulo_1.png "DPTP System") ![DPTP System](https://github.com/DPTPSystem/ColoringGridMaker/blob/master/images/repulo_2.png "DPTP System") ![DPTP System](https://github.com/DPTPSystem/ColoringGridMaker/blob/master/images/repulo_3.png "DPTP System")

![DPTP System](https://github.com/DPTPSystem/ColoringGridMaker/blob/master/images/repulo_grid.png "DPTP System")

# Kép előkészítése
A képet annak megfelelően készítem elő, hogy még is mekkora felbontásban és mennyi színnel akarok dolgozni. Kezdés képen mindenképp érdemes 
kisebb felbontást és kevesebb színvariációt választani, mert a túl nagy felbontás ás túl sok szín iszonyat koncentrációt és még több türelmet 
követel meg, főként a színek kikeverése és a sok részlet miatt. Képeket mindenképp BMP vagy is nyers formában konvertáljuk mert ez biztosítja a 
képek könnyebb feldolgozását, plusz a minőség is a legjobb. Fontos továbbá, hogy az elkészített képünk mérete (szélesség x magasság) 8-al 
osztható legyen, ha ez nem így van a program hibás megjelenítést fog követni. (később javítható)

# Program
Most íródik. A "folyamat" fejléc alatt részleteiben listázódik az előrehaladás.

# Kapcsolodó videós és képi tartalmak
Képi anyagok:

![DPTP System](https://github.com/DPTPSystem/ColoringGridMaker/blob/master/images/cgm1.JPG "DPTP System")

![DPTP System](https://github.com/DPTPSystem/ColoringGridMaker/blob/master/images/cgm2.JPG "DPTP System")

![DPTP System](https://github.com/DPTPSystem/ColoringGridMaker/blob/master/images/cgm3.JPG "DPTP System")

![DPTP System](https://github.com/DPTPSystem/ColoringGridMaker/blob/master/images/cgm4.JPG "DPTP System")

![DPTP System](https://github.com/DPTPSystem/ColoringGridMaker/blob/master/images/cgm5.JPG "DPTP System")

![DPTP System](https://github.com/DPTPSystem/ColoringGridMaker/blob/master/images/cgm6.JPG "DPTP System")

![DPTP System](https://github.com/DPTPSystem/ColoringGridMaker/blob/master/images/cgm7.JPG "DPTP System")
