# UVRG_Domaca_Naloga
Izdelajte grafični uporabniški vmesnik, ki bo uporabniku omogočal vnos poljubnega števila točk, ki bodo tvorile mnogokotnik. Po uspešnem vnosu točk mnogokotnika omogočite uporabniku vnos testne točke in za to testno točko boste preverili, če se nahaja znotraj mnogokotnika, ki ste ga prej vnesli. Preverjanje boste izvedli s pomočjo vsebnostnega testa s poltrakom (angl. ray crossing, ray intersection). Princip algoritma je preprost: iz točke, ki jo želimo testirati (testna točka) pošljemo poltrak v naključno smer in štejemo presečišča z mnogokotnikom. Če je število presečišč sodo, se točka nahaja izven mnogokotnika, če je liho pa je testna točka v mnogokotniku. 

 

Pri izvedbi algoritma lahko naletite na štiri različne scenarije, in sicer:

testna točka se nahaja na točki (oglišču) mnogokotnika
testna točka se nahaja na robu (stranici) mnogokotnika
testna točka se nahaja v mnogokotniku
testna točka se nahaja izven mnogokornika
Za vsakega izmed scenarijev si bomo v nadaljevanju pogledali, kako ga rešiti.

 

1. Testna točka se nahaja na točki (oglišču) mnogokotnika

koordinati (x in y) testne točke primerjajte z vsemi oglišči (kooordinati x in y) mnogotnika in v primeru, da se x in y koordinati ujemata, testna točka leži na oglišču
uporabniku izpišite, da testna točka leži na oglišču mnogokotnika in to oglišče pobarvajte drugače, kot ste ostala oglišča mnogokotnika

2. Testna točka se nahaja na robu (stranici) mnogokotnika

izračunajte kote med točkami Mi, T in Mi+1, kjer točki Mi in Mi+1 predstavljata sosednji oglišči mnogokotnika, T pa predstavlja našo testno točko
v primeru, da je izračunan kot enak 180°, to pomeni, da testna točka leži na robu mnogokotnika (upoštevate lahko napako pri računanju kota, recimo do 2°)
uporabniku izpišite, da testna točka leži na robu mnogokotnika in ta rob pobarvajte drugače, kot ste ostale robove mnogokotnika

3. Testna točka se nahaja v mnogokotniku

najprej moramo testno točko postaviti v izhodišče koordinatnega sistema (KS), to pa storimo tako, da vsaki točki (oglišču) mnogokotnika odštejemo testno točko (xm - xt in ym - yt, kjer xm in ym prestavljata koordinati oglišča mnogokotnika, xt in yt pa koordinati testne točke)

zatem pošljemo poltrak iz izhodišča KS v poljubno smer (v razlagi naloge ga bomo poslali vodoravno v levo smer - modra črta na zgornji sliki)
tukaj pa moramo preveriti tri stvari za vse stranice (robove) mnogokotnika (kvadranti so označeni z rimskimi številkami na zgornji sliki):
preverimo, če sta točki (Mi in Mi+1), ki tvorita stranico mnogokotnika vsaka v svojem kvadrantu, in sicer v drugem in tretjem (Mi v drugem in Mi+1 v tretjem kvadrantu (preverimo tudi obratno, če je Mi+1 v drugem in Mi v tretjem kvadrantu)) - če je ta pogoj izpolnjen, potem števec presečišč poltraka z mnogokotnikom povečamo za ena (številka 1 na spodnji sliki)
preverimo, če sta točki (Mi in Mi+1), ki tvorita stranico mnogokotnika vsaka v svojem kvadrantu, in sicer v prvem in tretjem (Mi v prvem in Mi+1 v tretjem kvadrantu (preverimo tudi obratno, če je Mi+1 v prvem in Mi v tretjem kvadrantu)) - če je ta pogoj izpolnjen, moramo izračunati D po naslednji enačbi D = (xi * yi+1 - xi+1 * yi) * (yi - yi+1), kjer sta x in y koordinati Mi in Mi+1 točk; v primeru, da je vrednost D pozitivna, števec presečišč poltraka z mnogokotnikom povečamo, drugače ne (številka 2 na spodnji sliki)
preverimo, če sta točki (Mi in Mi+1), ki tvorita stranico mnogokotnika vsaka v svojem kvadrantu, in sicer v drugem in četrtem (Mi v drugem in Mi+1 v četrtem kvadrantu (preverimo tudi obratno, če je Mi+1 v drugem in Mi v četrtem kvadrantu)) - če je ta pogoj izpolnjen, moramo izračunati D po naslednji enačbi D = (xi * yi+1 - xi+1 * yi) * (yi - yi+1), kjer sta x in y koordinati Mi in Mi+1 točk; v primeru, da je vrednost D pozitivna, števec presečišč poltraka z mnogokotnikom povečamo, drugače ne (številka 3 na spodnji sliki)
           

na koncu pa preverimo še, če je števec presečišč poltraka z mnogokotnikom liho število, kar pomeni, da je testna točka v mnogokotniku
uporabniku izpišite, da testna točka leži v mnogokotniku
 

4. Testna točka se nahaja izven mnogokornika

ponovimo enak postopek kot pri tretjem scenariju, le da tu preverimo, če je števec presečišč poltraka z mnogokotnikom sodo število, kar pomeni, da je testna točka izven mnogokotniku
uporabniku izpišite, da testna točka leži izven mnogokotnika
 

