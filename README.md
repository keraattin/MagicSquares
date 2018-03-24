# Sihirli Kareler
Sihirli kareler n*n (n>= 3) bir matrisin satır , sütun ve köşegenleri üzerinde yerleştirilen tüm sayıların toplamının aynı olduğu matrislerdir. Bu matrise sayıların uygun yerleştirilmesi için 3 farklı yaklaşım vardır.
- [x] n = Tek sayılar için
- [x] n/2 = Çift sayılar için
- [ ] n/2 = Tek sayılar için

## n = Tek sayılar için 

Tek sayıda satır ve sütuna sahip matrislerdir.
Sayıların uygun yerleştirilmesi için uygulanacak algoritma şu şekildedir :
**i = satır** , **j = sütun** olarak alınırsa;

Ilk olarak bir başlangıç değeri verilmelidir.
Başlangıç değerleri **i=0** ve **j= n/2** değerlerinden başlayıp. **i = i+1** , **j = j+1** şeklinde gidilerek bu 
noktalar üzerinde seçilmelidir. **i** veya **j** değeri n değerini aştığında o değer başa alınarak yani **0** 'a
eşitlenerek devam edilmelidir.

![1](/Images/1.png)	![2](/Images/2.png)

Burada istisnai bir durum vardır **n=3** için bu başlangıç yöntemi tek bir yerde geçerli olmaktadır.
Aksi takdirde köşegenlerdeki toplamlar birinde doğru çıkarken diğerinde yanlış çıkmaktadır.
Programda başlangıç noktası el ile veya rastgele seçilebilmektedir.
Başlangıç noktası seçildikten sonra **i = i+1** , **j= j+1** şeklinde ilerleyerek sayılar yerleştirilir. 
Eğer **i** veya **j** değeri **n** değerini aşarsa başa dönülür yani **0** noktasından başlayarak devam edilir.
Eğer **i+1**, **j+1** noktaları dolu ise **i = i** , **j = j-1** noktasından devam edilir.

![3](/Images/3.png)	![4](/Images/4.png)

![5](/Images/5.png)	![6](/Images/6.png)

Sonuç olarak satır, sütun ve köşegenleri eşit olan bir matris elde ediyoruz.
Tek değerler için beklenen toplam değeri : __((a0 + an) / 2) *n__

## n/2 = Çift sayılar için

Çift sayıda satır ve sütuna sahip matrislerdir.
Sayıların uygun yerleştirilmesi için uygulanacak algoritma şu şekildedir :
**i = satır** , **j = sütun** olarak alınırsa;
Başlangıçta bütün sayılar matrise yerleştirilir.

![7](/Images/7.png)	
 
Sonra matris **n/2** , **n/4** , **n/2** olarak bölümlere ayrılır.
 
![8](/Images/8.png)

**N/4** ün içerisinde olan **ai**,**aj** ile **a n-i** , **a n-j** sütunları arasında swap yapılır.

![9](/Images/9.png) ![10](/Images/10.png)

Swaplar yapıldıktan sonra oluşan satır,sütun ve köşegenler toplamı eşit olmaktadır.

Çift matris için beklenen değer tek matrisden farklıdır.
Çift matris için beklenen değer : __(((a0 + an) / 2) *n) + n/2__ olarak hesaplanır.