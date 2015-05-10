#BubbleTrouble
==============
Проект по Визуелно програмирање изработен од: 

Александар Дембовски 121193

Наталија Велкоска 122006

Милан Деспотовски 121024

За тема на нашата проектна задача ние одбравме да направиме игра чија идеја добива директна инспирација и имплементација на играта Bubble trouble. Кога се стартува играта се појавува мени преку кое има неколку опции кои можат да се извршат. Има опции за да се започне нова игра, да се смени карактер со кој играчот сака да ја започне играта, во овој случај се одбираат различни пингвини бидејќи ние се решивме да ги искористиме нив како тематика за нашата игра, и уште една опција за одкажување и затвoрање на самата игра. 

Изглед на Менито и селекција на карактер:

http://i.imgur.com/D8SWIF1.jpg
http://i.imgur.com/ugQvUxw.jpg

Играта се игра со три копчиња на тастатурата односно со копчињата UP,LEFT,RIGHT. Со копчињата LEFT и RIGHT се движи player, а со копчето UP се испукува линијата со која треба да се погодат балоните.

Кога ќе се стартува нова игра, од двете страни се појавуваат балони кои скокаат од едниот крај на арената до другиот крај и притоа играчот кој може да се движи во арената за одредено време треба да ги погоди овие балони со “bullet” што всушност е една линија која со притискање на копчето за пукање почнува да се исцртува од играчот вертикално, се до горниот дел од арената, кога ќе стигне линијата до крајот таа ичезнува, во меѓувреме секој балон кој ќе ја допре таа линија пука. 
Во еден момент може да постои само еден “bullet” се додека не исчезне таа линија играчот не може да испука уште еден “bullet”.

Изглед на играта:

http://i.imgur.com/O6qnO7b.jpg

Балоните се кругови кои се движат со константа брзина и скокаат низ арената, овие балони ако дојдат во допир со играчот, автоматски се ресетира играта и на играчот му се одзема “живот”. Постојат три вида на балони, големи, средни и мали. Овие балони сите имаат различен радиус, брзина, висина од која почнуваат да паѓаат, и брзина на паѓање. Балоните ако дојдат во допир со “bullet” пукаат, пукањето работи така што, ако голем или среден балон пукне се дели на два помали балони кои почнуваат да скокаат на две различни страни. Што значи Голем -> Среден -> Мал, ако мал балон пукне тогаш балонот исчезнува.  Има одредено време за кое играчот треба да ги пукне сите балони кое е претставено во една линија која се пополнува и стои под арената, ако се наполни таа линија, играчот губи “живот”.

Поделба на балоните:

http://i.imgur.com/vW8tIP2.jpg


За играчот се чуваат бројот на “животи” кои ако се потрошат се појавува Game Over прозорецот кој има две опции, да се почне нова игра или да се врати на почетното мени.  Целта на играчот треба да биде да ги испука сите балони за да продолжи во понатамошните нивоа кои се потешки. Наредните нивоа се потешки бидејќи имаат повеќе балони во исто време има на почетокот на играта.

GameOver Прозорецот:

http://i.imgur.com/sLVbxMt.jpg