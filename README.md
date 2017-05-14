# P101-P201--11.05.2017

## Virtual kart 

Virtual kart real olmayan bir bank kartıdır hansi ki onu sadəcə online alışveriş zamanı bank kartınızın təhlükəsizliyini təmin etmək üçün istifadə edirsiniz

**Xüsusiyyətləri**

1. Kart üzərindəki 16 rəqəmli hesab nömrəsi randomdur real kart nömrəsi ilə əlaqəsi yoxdur
2. Kart üzərindəki ad virtual kartı yaradan şəxs tərəfindən təyin olunur.
3. Kartın bitmə müddəti real kartın bitmə müddəti ilə eyni olmalıdır
4. 3 rəqəmli təhlükəsizlik kodu kart random olaraq yaranır
5. Virtual kartın təyin ediləbilməsi üçün ona istifadə müddəti təyin olunması şərtdir(Real kartın müddətindən uzun ola bilməz)
6. Virtual karta təyin edəcəyiniz məbləğ real kartdakı məbləğə bağlıdır. Bu səbəbdən hər yaranan virtual kart real kartdakı məbləğə əsaslanaraq təyin edilməlidir.


**Tələblər**

1. Real kart məlumatları öncədən daxil edilmiş sistemdə virtual kart yaradma mexanizmini təmin etməlisiniz


## Taksi sifariş sistemi

**Rollar**
1. Müştəri
   1. Adını (Nümunə Əhməd) və olduğu yeri qeyd etmək (START POINT ) (Bizim sistemimizdə koordinatlar daxil ediləcək nümunə (40k,50k) ) (input : Əhməd-40-50)
   2. Gedəcəyi yeri təyin etmə (END POINT ) (Bizim sistemimizdə koordinatlar daxil ediləcək nümunə (100k,250k) )
2. Operator 
   1. Müştərinin daxil etdiyi koordinatlara (START POINT) əsasən ən yaxında olan taksini təyin etmə 
   2. Hesablanan məsafəyə görə hər 10k-a görə 2 AZN xidmət haqqı hesablanması (Məsafə hesablanması üçün koordinat sistemində iki nöqtə arasındakı fərqi hesablama düsturundan istifadə edə bilərsiniz)
   3. Taksinin olduğu yerdən müştərinin adresinə çatma zamanını və müştərinin istədiyi adresə çatma zamanını hesablama (Taksinin sürəti 3 K/Dəqiqə)
   4. Təyin edilən taksinin müştəri ilə əlaqələndirmə ( output : Hörmətli Əhməd bəy sizin taksiniz təyin edildi.Taksiniz X dəqiqəyə adresinizdə olacaq, qeyd etdiyiniz adresə çatma vatxınız Y-dir və gediş haqqınız Z olacaqdır.Bizi seçdiyiniz üçün təşəkkür edirik )
3. Taksi
   1. Maşın nömrəsi və olduğu yeri təyin etmə (START POINT)
