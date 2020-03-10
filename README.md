Całość oparta jest wyłącznie na CPU.\
Scena składa się z:\
    3 siatek:\
        -nieruchoma niebiesa kostka,\
        -ruchoma zielona kostka, na której znajduje się jedna z 3 możliwych do wyboru kamer,\
        -sfera - do jej implementacji skorzystałem z rozwiązania znalezionego w internecie.\
                 Referencja znajduje się przy wywołaniu metod w kodzie źródłowym.\
    3 przełączalnych kamer: \
        -stacjonarna zawieszona w przestrzeni,\
        -stacjonarna podążająca za ruchomą kostką,\
        -ruchoma, związana z ruchomą kostką, nakierowana na kostke nieruchomą,\
    2 źródeł światła:\
        -punktowe\
        -reflektor orbitujący wokół początku układu współrzędnych,\
Zaimplementowane zostały 3 rodzaje cieniowania:\
    -stałe\
    -Gouraud'a\
    -Phong'a - tutaj wydajność znacznie spada,\
Położenie kamer stacjonarnych, tryb pracy kamery, a także rodzaj cieniowania można zmieniać korzystająć z interfejsu.

   
 