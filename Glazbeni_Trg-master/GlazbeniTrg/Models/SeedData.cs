using GlazbeniTrg.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GlazbeniTrg.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ApplicationDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>()))
            {


                if (context.Genre.Any())
                {
                    return;
                }
                var genres = new[]
                {
                    new Genre{ GenreName="Country"},
                    new Genre{ GenreName="Rock"},
                    new Genre{ GenreName="Pop"},
                    new Genre{ GenreName="Blues"},
                    new Genre{ GenreName="Folk"},
                    new Genre{ GenreName="Jazz"},
                    new Genre{ GenreName="Hip Hop"},
                    new Genre{ GenreName="House"},
                    new Genre{ GenreName="R'n'B"},
                    new Genre{ GenreName="Electro"},
                    new Genre{ GenreName="Punk"},
                    new Genre{ GenreName="Classical"},
                    new Genre{ GenreName="Dance"},
                    new Genre{ GenreName="Rap"},
                    new Genre{ GenreName="Reggae"},
                    new Genre{ GenreName="Indie"},
                    new Genre{ GenreName="Techno"},
                    new Genre{ GenreName="Swing"},
                    new Genre{ GenreName="Latino"},
                    new Genre{ GenreName="Soul"}
                };
                context.Genre.AddRange(genres);
                context.SaveChanges();

                if (context.Song.Any())
                {
                    return;
                }

                var songs = new[]
                {
                    new Song{SongName="Dobrodošao u klub", Duration=new TimeSpan(0,0,3,53), SongYear=DateTime.Parse("2012-12-14")},
                    new Song{SongName="Ko me tjero", Duration=new TimeSpan(0,0,3,8), SongYear=DateTime.Parse("2012-12-14")},
                    new Song{SongName="Uzbuna", Duration=new TimeSpan(0,0,3,33), SongYear=DateTime.Parse("2012-12-14")},
                    new Song{SongName="Italiana", Duration=new TimeSpan(0,0,4,9), SongYear=DateTime.Parse("2012-12-14")},
                    new Song{SongName="Kradeš sve", Duration=new TimeSpan(0,0,3,59), SongYear=DateTime.Parse("2012-12-14")},
                    new Song{SongName="Slaba na slabića", Duration=new TimeSpan(0,0,3,44), SongYear=DateTime.Parse("2012-12-14")},
                    new Song{SongName="Kamen oko vrata", Duration=new TimeSpan(0,0,3,37), SongYear=DateTime.Parse("2012-12-14")},
                    new Song{SongName="Grad bez ljudi", Duration=new TimeSpan(0,0,4,24), SongYear=DateTime.Parse("2011-12-20")},
                    new Song{SongName="Ostavljena", Duration=new TimeSpan(0,0,3,55), SongYear=DateTime.Parse("2012-12-14")},
                    new Song{SongName="Brad Pitt", Duration=new TimeSpan(0,0,4,12), SongYear=DateTime.Parse("2011-08-01")},
                    new Song{SongName="Postelja od vina", Duration=new TimeSpan(0,0,4,34), SongYear=DateTime.Parse("2012-12-14")},
                    new Song{SongName="Tarapana", Duration=new TimeSpan(0,0,3,20), SongYear=DateTime.Parse("2012-12-14")},
                    new Song{SongName="Tango", Duration=new TimeSpan(0,0,3,19), SongYear=DateTime.Parse("2012-12-14")},

                    new Song{SongName="Come Together", Duration=new TimeSpan(0,0,4,20), SongYear=DateTime.Parse("1969-09-26")},
                    new Song{SongName="Something", Duration=new TimeSpan(0,0,3,03), SongYear=DateTime.Parse("1969-09-26")},
                    new Song{SongName="Maxwell's Silver Hammer", Duration=new TimeSpan(0,0,3,27), SongYear=DateTime.Parse("1969-09-26")},
                    new Song{SongName="Oh! Darling", Duration=new TimeSpan(0,0,3,26), SongYear=DateTime.Parse("1969-09-26")},
                    new Song{SongName="Octopus's Garden", Duration=new TimeSpan(0,0,2,51), SongYear=DateTime.Parse("1969-09-26")},
                    new Song{SongName="I Want You", Duration=new TimeSpan(0,0,7,47), SongYear=DateTime.Parse("1969-09-26")},
                    new Song{SongName="Here Comes the Sun", Duration=new TimeSpan(0,0,3,05), SongYear=DateTime.Parse("1969-09-26")},
                    new Song{SongName="Because", Duration=new TimeSpan(0,0,2,45), SongYear=DateTime.Parse("1969-09-26")},
                    new Song{SongName="You Never Give Me Your Money", Duration=new TimeSpan(0,0,4,02), SongYear=DateTime.Parse("1969-09-26")},
                    new Song{SongName="Sun King", Duration=new TimeSpan(0,0,2,26), SongYear=DateTime.Parse("1969-09-26")},
                    new Song{SongName="Mean Mr. Mustard", Duration=new TimeSpan(0,0,1,06), SongYear=DateTime.Parse("1969-09-26")},
                    new Song{SongName="Polythene Pam", Duration=new TimeSpan(0,0,1,12), SongYear=DateTime.Parse("1969-09-26")},
                    new Song{SongName="She Came Throuhg the Bathroom Window", Duration=new TimeSpan(0,0,1,57), SongYear=DateTime.Parse("1969-09-26")},
                    new Song{SongName="Golden Slumbers", Duration=new TimeSpan(0,0,1,31), SongYear=DateTime.Parse("1969-09-26")},
                    new Song{SongName="Carry That Weight", Duration=new TimeSpan(0,0,1,36), SongYear=DateTime.Parse("1969-09-26")},
                    new Song{SongName="The End", Duration=new TimeSpan(0,0,2,05), SongYear=DateTime.Parse("1969-09-26")},
                    new Song{SongName="Her Majesty", Duration=new TimeSpan(0,0,0,23), SongYear=DateTime.Parse("1969-09-26")},

                    new Song{SongName="William,It Was Really Nothing", Duration=new TimeSpan(0,0,2,9), SongYear=DateTime.Parse("1984-08-20")},
                    new Song{SongName="What Difference Does It Make?", Duration=new TimeSpan(0,0,3,11), SongYear=DateTime.Parse("1984-05-21")},
                    new Song{SongName="This things Take Time", Duration=new TimeSpan(0,0,2,32), SongYear=DateTime.Parse("1984-05-21")},
                    new Song{SongName="This Charming Man", Duration=new TimeSpan(0,0,2,42), SongYear=DateTime.Parse("1984-01-28")},
                    new Song{SongName="How Soon Is Now?", Duration=new TimeSpan(0,0,6,44), SongYear=DateTime.Parse("1984-05-21")},
                    new Song{SongName="Handsome Devil", Duration=new TimeSpan(0,0,2,47), SongYear=DateTime.Parse("1984-05-21")},
                    new Song{SongName="Hand In Glove", Duration=new TimeSpan(0,0,3,13), SongYear=DateTime.Parse("1984-05-21")},
                    new Song{SongName="Still Ill", Duration=new TimeSpan(0,0,3,32), SongYear=DateTime.Parse("1984-05-21")},
                    new Song{SongName="Heaven Knows I'm Miserable Now", Duration=new TimeSpan(0,0,3,33), SongYear=DateTime.Parse("1984-05-21")},
                    new Song{SongName="This Night Has Opened My Eyes", Duration=new TimeSpan(0,0,3,39), SongYear=DateTime.Parse("1984-05-21")},
                    new Song{SongName="You've Got Everything Now", Duration=new TimeSpan(0,0,4,18), SongYear=DateTime.Parse("1984-05-21")},
                    new Song{SongName="Accept Yourself", Duration=new TimeSpan(0,0,4,1), SongYear=DateTime.Parse("1984-05-21")},
                    new Song{SongName="Girl Afraid", Duration=new TimeSpan(0,0,2,48), SongYear=DateTime.Parse("1984-05-21")},
                    new Song{SongName="Back to the Old House", Duration=new TimeSpan(0,0,3,2), SongYear=DateTime.Parse("1984-05-21")},
                    new Song{SongName="Reel Around the Fountain", Duration=new TimeSpan(0,0,5,51), SongYear=DateTime.Parse("1984-05-21")},
                    new Song{SongName="Please, Please, Please, Let Me Get What I Want", Duration=new TimeSpan(0,0,1,50), SongYear=DateTime.Parse("1984-05-21")}
                };
                context.Song.AddRange(songs);
                context.SaveChanges();

                if (context.Label.Any())
                {
                    return;
                }
                var labels = new[]{
                    new Label{LabelName="Dallas Records", Albums=new List<Album>()},
                    new Label{LabelName="Apple Records",Albums=new List<Album>()},
                    new Label{LabelName="Rough Trade",Albums=new List<Album>()}
                };
                context.Label.AddRange(labels);
                context.SaveChanges();

                if (context.Album.Any())
                {
                    return;
                }
                var albums = new[]
                {
                    new Album{AlbumName="Dobrodošao u klub",AlbumYear=DateTime.Parse("2012-12-21"),Format=Media.CD,Stock=103,Price=decimal.Parse("150,00"),AvgGrade=0, Description="Dobrodošao u klub jedanaesti je studijski album hrvatske pop pjevačice Severine, kojeg 14. prosinca 2012. godine objavljuje diskografska kuća Dallas Records. Na albumu su sudjelovali brojni glazbenici, neki od njih su Hari Varešanović, Fahrudin Pecikoza, Branimir Mihaljević, Dušan Alagić, Dušan Bačić, Nikša Bratoš i sama Severina, koja potpisuje glazbu i tekst za pjesmu Ostavljena.Na albumu se nalazi trinaest pjesama, od kojih su tri dueta, 'Tango' s Željkom Bebekom, 'Italiana' s FM Bandom i 'Postelja od vina' s DJ-XLom. Izdano je šest singlova: 'Brad Pitt', 'Grad bez ljudi', 'Italiana', 'Uzbuna', 'Dobrodošao u klub' i 'Ostavljena'.",ImagePath="https://upload.wikimedia.org/wikipedia/en/thumb/e/ef/Severina_-_Dobrodosao_u_Klub_-_Cover.jpg/220px-Severina_-_Dobrodosao_u_Klub_-_Cover.jpg", Label=labels[0]},
                    new Album{AlbumName="Abbey Road",AlbumYear=DateTime.Parse("1969-09-26"),Format=Media.VINYL,Stock=150,Price=decimal.Parse("210,00"),AvgGrade=0, Description="Abbey Road album je Beatlesa iz 1969. godine. Smatra se jednim od njihovih najboljih albuma i jednim od vrhunaca rock glazbe uopće. Razlog za to je svakako splet pjesama (long medley) koji se nalazio na drugoj strani ploče a u kojem je isprepleteno osam kraćih pjesama. Naglašene dramatičnosti ('osjeća se da je to kraj'), medley i završava pjesmom 'The End', da bi album opet oživio na dvadesetak sekundi pjesmom 'Her Majesty'. Ostatak albuma je također briljantan: album započinje pjesmom 'Come Together' koju je John Lennon napisao za 'proroka LSD-a' Timothyja Learyja, napisanoj u struji svijesti, a nastavlja pjesmom 'Something', ponajboljim Harrisonovom doprinosom grupi. Pjesme poput 'Here Comes The Sun', 'Because', 'Oh! Darling' i 'Octopus's Garden' (druga Ringova pjesma u Beatlesima) također su postale hitovi i smatraju se vrhunskim ostvarenjima.", ImagePath="https://upload.wikimedia.org/wikipedia/en/4/42/Beatles_-_Abbey_Road.jpg", Label=labels[1]},
                    new Album{AlbumName="Hatfull of Hollow",AlbumYear=DateTime.Parse("1984-05-21"),Format=Media.CD,Stock=178,Price=decimal.Parse("321,99"),AvgGrade=0,Description="Hatful of Hollow je kompilacijski album engleskog rock benda The Smiths. Objavljen je 12. studenog 1984.Album je dosegao broj 7 na britanskoj top ljestvici te ostao na njoj 46 tjedana. Album se sastoji uglavnom od pjesama snimljenih tijekom nekoliko BBC Radio 1 sesija 1983. godine.  ",ImagePath="https://i.pinimg.com/474x/4e/76/83/4e7683a8da0fe9695fde708c98350430--hatful-of-hollow-the-smiths.jpg", Label=labels[2] }
                };
                context.Album.AddRange(albums);
                context.SaveChanges();

                if (context.Country.Any())
                {
                    return;
                }
                var countries = new[]{
                    new Country { CountryName = "Hrvatska" ,Cities=new List<City>()},
                    new Country { CountryName = "BiH",Cities=new List<City>() },
                    new Country { CountryName = "Slovenija",Cities=new List<City>()}
                 };
                context.Country.AddRange(countries);
                context.SaveChanges();

                if (context.Person.Any())
                {
                    return;
                }
                var persons = new[]
                {
                    new Person{FirstName="Nikša", LastName="Bratoš", Bio="Nikša Bratoš (Travnik, 17. kolovoza 1959.) je hrvatski - bosanskohercegovački skladatelj zabavne i pop glazbe, i jedan od najznačajnijih bosanskohercegovačkih aranžera. Autor je velikog broja pjesama grupe 'Crvena jabuka' i Borisa Novkovića."},
                    new Person{FirstName="Branimir", LastName="Mihaljević", Bio="Branimir Mihaljević (1975) je skladatelj, aranžer i glazbeni producent. Glazbeno obrazovanje stekao je u srednjoj glazbenoj školi Vatroslava Lisinkog u rodnom Zagrebu, a paralelno već u tinejđerskim danima stječe iskustvo studijskih snimanja te već sa 16 godina aranžira prve albume koji se prodaju u zlatnim tiražama.Do danas njegov autorski rad u domeni zabavne glazbe broji stotine pjesama koje su otpjevali neki od najpopularnijih izvođača u regiji među kojima su Željko Bebek, Crvena jabuka, Oliver Dragojević, Mišo Kovač, Zlatko Pejaković, Giuliano, Nina Badrić, Severina..."},
                    new Person{FirstName="Filip", LastName="Miletić", Bio=""},
                    new Person{FirstName="Miloš", LastName="Roganović", Bio=""},
                    new Person{FirstName="Dušan", LastName="Alagić", Bio=""},
                    new Person{FirstName="Severina", LastName="Vučković", Bio="Severina Vučković (Split, 21. travnja 1972.), hrvatska je pop pjevačica. Dobitinica je nagrade 'Zlatna ptica', za najtiražnijega izvođača desetljeća u Hrvatskoj, nagrade 'Večernjakova ruža' za ženskog izvođača godine 2002. godine, te nagrade 'Zlatna bubamara' za izvođača godine u Makedoniji, kao i mnogih drugih. Njene najpoznatije pjesme su: 'Tvoja prva djevojka', 'Dalmatinka', 'Trava zelena', 'Djevojka sa sela', 'Ja samo pjevam', 'Virujen u te', 'Pogled ispod obrva', 'Moja štikla', 'Gas, gas', 'Tridesete', 'Brad Pitt', 'Uzbuna', 'Dobrodošao u klub', 'Uno momento' i druge."},

                    new Person{FirstName="John", LastName="Lennon", Bio="John Winston Ono Lennon (Liverpool, 9. listopada 1940. - New York, 8. prosinca 1980.) engleski glazbenik, skladatelj, tekstopisac, pjevač i gitarist najpopularnije glazbene grupe 20. stoljeća, Beatlesa."},
                    new Person{FirstName="Paul", LastName="McCartney", Bio="Sir James Paul McCartney MBE (Liverpool, 18. lipnja 1942.) je britanski glazbenik i slikar, bivši član Beatlesa. Paul McCartney je glazbena ikona dvadesetog stoljeća. U Guinnessovoj knjizi rekorda navodi ga se kao glazbenika s najviše pjesama na vrhu glazbenih ljestvica (samo u SAD-u 29 njegovih pjesama 'stiglo' je do broja 1.Najbogatiji je glazbenik današnjice."},
                    new Person{FirstName="George", LastName="Harrison", Bio="George Harrison (Liverpool, 25. veljače 1943. - Los Angeles, 29. studenog 2001.) bio je engleski gitarist, pjevač, skladatelj, producent, a najpoznatiji kao član Beatlesa.George Harrison je u Beatlesima svirao solo gitaru i bio je dobar gitarist te puno pridonio specifičnom zvuku Beatlesa. Njegove osebujne pjesme uvrštene u neke od albuma Beatlesa uvijek su dale ekspresivnu diskurzivnost u glazbenom stilu same grupe."},
                    new Person{FirstName="Ringo", LastName="Starr", Bio="Richard Starkey, poznatiji pod pseudonimom Ringo Starr (Liverpool, 7. srpnja 1940.) bio je bubnjar u Beatlesima od 1962. do 1970. godine. Pjevao je u brojnim poznatim pjesmama Beatlesa (poput Yellow Submarine i With a Little Help From My Friends te Beatles verzije pjesme Act naturally), a napisao je pjesme Don't Pass Me By i Octopus Garden. "},
                    new Person{FirstName="George", LastName="Martin", Bio="Sir George (Henry) Martin (3. siječnja, 1926. – 8. ožujka 2016.)[1] slavni je britanski glazbeni producent, aranžer i skladatelj. Ponekad ga navode kao petog Beatlesa, jer je bio producent (ili koproducent) čitavog izvornog opusa Beatlesa, a na nekim snimkama je on taj koji svira klavir. Martinovo glazbeno znanje, dobro je došlo da se premosti jaz između sirovog talenta Beatlesa , i glazbenog učinka koji su oni htjeli polučiti. Većinu aranžmana koji su uključivali; orkestar, ili dionice sa glasovirom(ili drugim instrumentima na tipke), bili su napisani i izvedeni od Georga Martina, u suradnji sa grupom. Njegova ideja je bila da pratnja pjesmi - Yesterday (McCartneya) bude violinski kvartet u stilu i duhu Bacha da se istakne vokal McCartneya. Njegov aranžerski utjecaj, vidljiv je i u drugim skladbama Beatlesa poput; Penny Lane, Eleanor Rigby i mnogih drugih."},
                    new Person{FirstName="Geoff", LastName="Emerick", Bio="Geoffrey Emerick (rođen 1946.) engleski je inženjer za snimanje zvuka. Radio je s The Beatlesima na albumima kao što su The Beatles, Abbey Road... Dobio je nagradu Grammy za album Abbey Road. Dobitnik je četiti Grammy nagrada."},//11

                    new Person{FirstName="Steven Patrick", LastName="Morrissey", Bio="Steven Patrick Morrissey je britanski glazbenik. Postao je poznat kao tekstopisac i pjevač sastava The Smiths. Nakon razlaza ovog sastava nastavlja uspješnu samostalnu karijeru."}, //12
                    new Person{FirstName="Johnny", LastName="Marr", Bio="Johnny Marr (rođen John Martin Maher , 31. listopada 1963.) engleski je glazbenik, tekstopisac i pjevač, najpoznatiji kao gitarist te tekstopisac grupe The Smiths"}, //13
                    new Person{FirstName="Andy", LastName="Rourke", Bio="Andrew Michael Rourke (rođen 17. siječnja 1964.) engleski je glazbenik najpoznatiji kao basist grupe The Smiths."}, //14
                    new Person{FirstName="Mike", LastName="Joyce", Bio="Michael Adrian Paul Joyce (rođen 1.lipnja 1963.) je engleski bubnjar. Najpoznatiji je kao bubnjar grupe The Smiths, engleski rock band koji je formiran u Manchesteru 1982. godine. "}, //15
                    new Person{FirstName="John", LastName="Porter", Bio="John Porter (rođen 11. rujna 1947. u Leedsu ) engleski je glazbenik i producent. Porter je producirao albume mnogih poznatih izvođača kao što su The Smiths, Billy Bragg, BB King, Ryan Adams... "}, //16
                    new Person{FirstName="Roger", LastName="Pusey", Bio="Roger Pusey je bivši producent BBC Radio 1 koji je radio na Peel Sessionsu. Producirao je brojne pjesme za grupu The Smiths uključujući 'This Charming Man' i 'What Difference Does It Make'. Osim toga, Roger je producirao pjesme za Davida Bowiea te za bend New Model Army"}, //17

                    new Person{FirstName="The Beatles",Bio="The Beatles je kultni rock i pop sastav iz Liverpoola, Velika Britanija. Jedan su od najkomercijalnijih, najuspješnijih i najpopularnijih sastava u povijesti rock glazbe."}, //18
                    new Person{FirstName="The Smiths ",Bio="The Smiths je bio britanski alternativni rock sastav koji je nastao 1982. u Manchesteru. Članovi benda bili su Morrissey (vokali), Johnny Marr (gitara), Andy Rourke (bas) te Mike Joyce na bubnjevima. Kritičari ih smatraju jednim od najboljih alternativnih sastava britanske indie scene 1980-ih. Izdali su četiri studijska albuma, a 1987. su se raspali."} //19
                    
                };
                context.Person.AddRange(persons);
                context.SaveChanges();

                albums[0].Songs.Add(songs[0]);
                albums[0].Songs.Add(songs[1]);
                albums[0].Songs.Add(songs[2]);
                albums[0].Songs.Add(songs[3]);
                albums[0].Songs.Add(songs[4]);
                albums[0].Songs.Add(songs[5]);
                albums[0].Songs.Add(songs[6]);
                albums[0].Songs.Add(songs[7]);
                albums[0].Songs.Add(songs[8]);
                albums[0].Songs.Add(songs[9]);
                albums[0].Songs.Add(songs[10]);
                albums[0].Songs.Add(songs[11]);
                albums[0].Songs.Add(songs[12]);

                albums[1].Songs.Add(songs[13]);
                albums[1].Songs.Add(songs[14]);
                albums[1].Songs.Add(songs[15]);
                albums[1].Songs.Add(songs[16]);
                albums[1].Songs.Add(songs[17]);
                albums[1].Songs.Add(songs[18]);
                albums[1].Songs.Add(songs[19]);
                albums[1].Songs.Add(songs[20]);
                albums[1].Songs.Add(songs[21]);
                albums[1].Songs.Add(songs[22]);
                albums[1].Songs.Add(songs[23]);
                albums[1].Songs.Add(songs[24]);
                albums[1].Songs.Add(songs[25]);
                albums[1].Songs.Add(songs[26]);
                albums[1].Songs.Add(songs[27]);
                albums[1].Songs.Add(songs[28]);
                albums[1].Songs.Add(songs[29]);

                albums[2].Songs.Add(songs[30]);
                albums[2].Songs.Add(songs[31]);
                albums[2].Songs.Add(songs[32]);
                albums[2].Songs.Add(songs[33]);
                albums[2].Songs.Add(songs[34]);
                albums[2].Songs.Add(songs[35]);
                albums[2].Songs.Add(songs[36]);
                albums[2].Songs.Add(songs[37]);
                albums[2].Songs.Add(songs[38]);
                albums[2].Songs.Add(songs[39]);
                albums[2].Songs.Add(songs[40]);
                albums[2].Songs.Add(songs[41]);
                albums[2].Songs.Add(songs[42]);
                albums[2].Songs.Add(songs[43]);
                albums[2].Songs.Add(songs[44]);
                albums[2].Songs.Add(songs[45]);
                 
                albums[0].Genres.Add(genres[2]);
                albums[0].Genres.Add(genres[4]);

                albums[1].Genres.Add(genres[1]);

                albums[2].Genres.Add(genres[15]);
                albums[2].Genres.Add(genres[1]);

                for (int i = 0; i < 13; i++)
                {
                    songs[i].Genres.Add(genres[2]);
                    songs[i].Genres.Add(genres[4]);
                };

                for (int i = 13; i < 30; i++)
                {
                    songs[i].Genres.Add(genres[1]);
                };

                for (int i = 30; i < 46; i++)
                {
                    songs[i].Genres.Add(genres[15]);
                    songs[i].Genres.Add(genres[1]);
                };

                labels[0].Albums.Add(albums[0]);
                labels[1].Albums.Add(albums[1]);
                labels[2].Albums.Add(albums[2]);

                context.SaveChanges();

                if (context.SongPerson.Any())
                {
                    return;
                }
                var songPersons = new[]
                {
                    new SongPerson{Song=songs[0],Person=persons[3],Function=Function.COMPOSER | Function.SONGWRITER | Function.PRODUCER},
                    new SongPerson{Song=songs[0],Person=persons[2],Function=Function.PRODUCER},
                    new SongPerson{Song=songs[0],Person=persons[4],Function=Function.PRODUCER},
                    new SongPerson{Song=songs[0],Person=persons[5],Function=Function.PERFORMER},
                    new SongPerson{Song=songs[1],Person=persons[3],Function=Function.COMPOSER | Function.PRODUCER},
                    new SongPerson{Song=songs[1],Person=persons[5],Function=Function.PERFORMER | Function.SONGWRITER},
                    new SongPerson{Song=songs[1],Person=persons[2],Function=Function.COMPOSER | Function.PRODUCER},
                    new SongPerson{Song=songs[1],Person=persons[4],Function=Function.PRODUCER },
                    new SongPerson{Song=songs[2],Person=persons[5],Function=Function.PERFORMER},
                    new SongPerson{Song=songs[2],Person=persons[2],Function=Function.SONGWRITER | Function.PRODUCER},
                    new SongPerson{Song=songs[2],Person=persons[3],Function=Function.PRODUCER |Function.COMPOSER},
                    new SongPerson{Song=songs[3],Person=persons[5],Function=Function.PERFORMER},
                    new SongPerson{Song=songs[3],Person=persons[2],Function=Function.SONGWRITER | Function.PRODUCER},
                    new SongPerson{Song=songs[3],Person=persons[3],Function=Function.PRODUCER |Function.COMPOSER},
                    new SongPerson{Song=songs[4],Person=persons[3],Function=Function.SONGWRITER | Function.PRODUCER},
                    new SongPerson{Song=songs[4],Person=persons[5],Function=Function.PERFORMER},
                    new SongPerson{Song=songs[4],Person=persons[2],Function=Function.PRODUCER},
                    new SongPerson{Song=songs[4],Person=persons[4],Function=Function.PRODUCER |Function.COMPOSER},
                    new SongPerson{Song=songs[5],Person=persons[0],Function=Function.SONGWRITER | Function.PRODUCER},
                    new SongPerson{Song=songs[5],Person=persons[3],Function=Function.PRODUCER |Function.COMPOSER},
                    new SongPerson{Song=songs[5],Person=persons[5],Function=Function.PERFORMER},
                    new SongPerson{Song=songs[6],Person=persons[5],Function=Function.PERFORMER},
                    new SongPerson{Song=songs[6],Person=persons[3],Function=Function.SONGWRITER | Function.COMPOSER | Function.PRODUCER},
                    new SongPerson{Song=songs[6],Person=persons[2],Function=Function.PRODUCER},
                    new SongPerson{Song=songs[6],Person=persons[4],Function=Function.PRODUCER},
                    new SongPerson{Song=songs[7],Person=persons[5],Function=Function.PERFORMER},
                    new SongPerson{Song=songs[7],Person=persons[2],Function=Function.PRODUCER | Function.SONGWRITER},
                    new SongPerson{Song=songs[7],Person=persons[3],Function=Function.COMPOSER | Function.PRODUCER},
                    new SongPerson{Song=songs[7],Person=persons[4],Function=Function.PRODUCER},
                    new SongPerson{Song=songs[8],Person=persons[5],Function=Function.PERFORMER | Function.COMPOSER | Function.SONGWRITER},
                    new SongPerson{Song=songs[8],Person=persons[2],Function=Function.PRODUCER},
                    new SongPerson{Song=songs[8],Person=persons[3],Function=Function.PRODUCER},
                    new SongPerson{Song=songs[9],Person=persons[2],Function=Function.PRODUCER | Function.SONGWRITER},
                    new SongPerson{Song=songs[9],Person=persons[3],Function=Function.PRODUCER | Function.COMPOSER},
                    new SongPerson{Song=songs[9],Person=persons[5],Function=Function.PERFORMER},
                    new SongPerson{Song=songs[10],Person=persons[1],Function=Function.SONGWRITER},
                    new SongPerson{Song=songs[10],Person=persons[2],Function=Function.COMPOSER | Function.PRODUCER},
                    new SongPerson{Song=songs[10],Person=persons[5],Function=Function.PERFORMER},
                    new SongPerson{Song=songs[11],Person=persons[5],Function=Function.PERFORMER},
                    new SongPerson{Song=songs[11],Person=persons[4],Function=Function.COMPOSER | Function.SONGWRITER | Function.PRODUCER},
                    new SongPerson{Song=songs[12],Person=persons[5],Function=Function.PERFORMER},
                    new SongPerson{Song=songs[12],Person=persons[1],Function=Function.PRODUCER | Function.COMPOSER | Function.SONGWRITER},

                    new SongPerson{Song=songs[13],Person=persons[6],Function=Function.SONGWRITER | Function.COMPOSER | Function.SINGER },
                    new SongPerson{Song=songs[13],Person=persons[7],Function=Function.PERFORMER | Function.SONGWRITER | Function.SINGER},
                    new SongPerson{Song=songs[13],Person=persons[8],Function=Function.GUITARIST},
                    new SongPerson{Song=songs[13],Person=persons[9],Function=Function.DRUMMER},
                    new SongPerson{Song=songs[13],Person=persons[10],Function=Function.PRODUCER},
                    new SongPerson{Song=songs[13],Person=persons[11],Function=Function.PRODUCER | Function.COMPOSER},
                    new SongPerson{Song=songs[14],Person=persons[8],Function=Function.SONGWRITER | Function.GUITARIST },
                    new SongPerson{Song=songs[14],Person=persons[7],Function=Function.SINGER | Function.COMPOSER},
                    new SongPerson{Song=songs[14],Person=persons[6],Function=Function.SINGER | Function.COMPOSER},
                    new SongPerson{Song=songs[14],Person=persons[9],Function=Function.DRUMMER},
                    new SongPerson{Song=songs[14],Person=persons[10],Function=Function.PRODUCER},
                    new SongPerson{Song=songs[15],Person=persons[7],Function=Function.SONGWRITER | Function.SINGER | Function.COMPOSER},
                    new SongPerson{Song=songs[15],Person=persons[6],Function=Function.SONGWRITER | Function.SINGER },
                    new SongPerson{Song=songs[15],Person=persons[8],Function=Function.GUITARIST},
                    new SongPerson{Song=songs[15],Person=persons[9],Function=Function.DRUMMER},
                    new SongPerson{Song=songs[15],Person=persons[11],Function=Function.PRODUCER},
                    new SongPerson{Song=songs[15],Person=persons[10],Function=Function.PRODUCER},
                    new SongPerson{Song=songs[16],Person=persons[7],Function=Function.SONGWRITER | Function.COMPOSER},
                    new SongPerson{Song=songs[16],Person=persons[6],Function=Function.SONGWRITER | Function.SINGER },
                    new SongPerson{Song=songs[16],Person=persons[8],Function=Function.GUITARIST },
                    new SongPerson{Song=songs[16],Person=persons[9],Function=Function.DRUMMER},
                    new SongPerson{Song=songs[16],Person=persons[10],Function=Function.PRODUCER},
                    new SongPerson{Song=songs[17],Person=persons[9],Function=Function.COMPOSER | Function.SONGWRITER | Function.DRUMMER},
                    new SongPerson{Song=songs[17],Person=persons[6],Function=Function.SINGER },
                    new SongPerson{Song=songs[17],Person=persons[7],Function=Function.SINGER},
                    new SongPerson{Song=songs[17],Person=persons[8],Function=Function.DRUMMER},
                    new SongPerson{Song=songs[17],Person=persons[10],Function=Function.PRODUCER},
                    new SongPerson{Song=songs[18],Person=persons[6],Function=Function.COMPOSER | Function.SONGWRITER | Function.SINGER },
                    new SongPerson{Song=songs[18],Person=persons[7],Function=Function.SINGER | Function.SONGWRITER},
                    new SongPerson{Song=songs[18],Person=persons[8],Function=Function.GUITARIST},
                    new SongPerson{Song=songs[18],Person=persons[9],Function=Function.DRUMMER},
                    new SongPerson{Song=songs[18],Person=persons[10],Function=Function.PRODUCER},
                    new SongPerson{Song=songs[19],Person=persons[8],Function=Function.COMPOSER | Function.SONGWRITER | Function.GUITARIST},
                    new SongPerson{Song=songs[19],Person=persons[7],Function= Function.SINGER },
                    new SongPerson{Song=songs[19],Person=persons[9],Function=Function.DRUMMER},
                    new SongPerson{Song=songs[19],Person=persons[10],Function=Function.PRODUCER | Function.COMPOSER},
                    new SongPerson{Song=songs[20],Person=persons[6],Function=Function.COMPOSER | Function.SONGWRITER | Function.SINGER},
                    new SongPerson{Song=songs[20],Person=persons[7],Function=Function.SONGWRITER | Function.SINGER },
                    new SongPerson{Song=songs[20],Person=persons[8],Function=Function.GUITARIST },
                    new SongPerson{Song=songs[20],Person=persons[9],Function=Function.DRUMMER},
                    new SongPerson{Song=songs[20],Person=persons[10],Function=Function.PRODUCER},
                    new SongPerson{Song=songs[21],Person=persons[6],Function=Function.SONGWRITER | Function.SINGER},
                    new SongPerson{Song=songs[21],Person=persons[7],Function=Function.SONGWRITER | Function.SINGER },
                    new SongPerson{Song=songs[21],Person=persons[8],Function=Function.GUITARIST},
                    new SongPerson{Song=songs[21],Person=persons[9],Function=Function.DRUMMER},
                    new SongPerson{Song=songs[21],Person=persons[10],Function=Function.PRODUCER | Function.COMPOSER},
                    new SongPerson{Song=songs[22],Person=persons[6],Function=Function.SONGWRITER | Function.SINGER | Function.COMPOSER},
                    new SongPerson{Song=songs[22],Person=persons[7],Function=Function.SONGWRITER | Function.SINGER },
                    new SongPerson{Song=songs[22],Person=persons[8],Function=Function.GUITARIST},
                    new SongPerson{Song=songs[22],Person=persons[9],Function=Function.DRUMMER},
                    new SongPerson{Song=songs[22],Person=persons[10],Function=Function.PRODUCER},
                    new SongPerson{Song=songs[23],Person=persons[6],Function=Function.SONGWRITER | Function.SINGER | Function.COMPOSER},
                    new SongPerson{Song=songs[23],Person=persons[7],Function=Function.SONGWRITER | Function.SINGER },
                    new SongPerson{Song=songs[23],Person=persons[8],Function=Function.GUITARIST},
                    new SongPerson{Song=songs[23],Person=persons[9],Function=Function.DRUMMER},
                    new SongPerson{Song=songs[23],Person=persons[10],Function=Function.PRODUCER},
                    new SongPerson{Song=songs[24],Person=persons[6],Function=Function.SINGER | Function.SONGWRITER | Function.COMPOSER},
                    new SongPerson{Song=songs[24],Person=persons[7],Function=Function.SONGWRITER | Function.SINGER},
                    new SongPerson{Song=songs[24],Person=persons[8],Function=Function.GUITARIST},
                    new SongPerson{Song=songs[24],Person=persons[9],Function=Function.DRUMMER},
                    new SongPerson{Song=songs[24],Person=persons[10],Function=Function.PRODUCER},
                    new SongPerson{Song=songs[25],Person=persons[6],Function=Function.SINGER},
                    new SongPerson{Song=songs[25],Person=persons[7],Function=Function.SONGWRITER | Function.SINGER | Function.COMPOSER },
                    new SongPerson{Song=songs[25],Person=persons[8],Function=Function.GUITARIST},
                    new SongPerson{Song=songs[25],Person=persons[9],Function=Function.DRUMMER},
                    new SongPerson{Song=songs[25],Person=persons[10],Function=Function.PRODUCER},
                    new SongPerson{Song=songs[26],Person=persons[6],Function=Function.SINGER},
                    new SongPerson{Song=songs[26],Person=persons[7],Function=Function.SONGWRITER | Function.SINGER | Function.COMPOSER },
                    new SongPerson{Song=songs[26],Person=persons[8],Function=Function.GUITARIST},
                    new SongPerson{Song=songs[26],Person=persons[9],Function=Function.DRUMMER},
                    new SongPerson{Song=songs[26],Person=persons[10],Function=Function.PRODUCER},
                    new SongPerson{Song=songs[27],Person=persons[6],Function=Function.SINGER},
                    new SongPerson{Song=songs[27],Person=persons[7],Function=Function.SONGWRITER | Function.SINGER | Function.COMPOSER },
                    new SongPerson{Song=songs[27],Person=persons[8],Function=Function.GUITARIST},
                    new SongPerson{Song=songs[27],Person=persons[9],Function=Function.DRUMMER},
                    new SongPerson{Song=songs[27],Person=persons[10],Function=Function.PRODUCER},
                    new SongPerson{Song=songs[28],Person=persons[6],Function=Function.SINGER | Function.SONGWRITER},
                    new SongPerson{Song=songs[28],Person=persons[7],Function=Function.SONGWRITER | Function.SINGER | Function.COMPOSER },
                    new SongPerson{Song=songs[28],Person=persons[8],Function=Function.GUITARIST},
                    new SongPerson{Song=songs[28],Person=persons[9],Function=Function.DRUMMER},
                    new SongPerson{Song=songs[28],Person=persons[10],Function=Function.PRODUCER},
                    new SongPerson{Song=songs[29],Person=persons[6],Function=Function.SINGER | Function.SONGWRITER},
                    new SongPerson{Song=songs[29],Person=persons[7],Function=Function.SONGWRITER | Function.SINGER | Function.COMPOSER },
                    new SongPerson{Song=songs[29],Person=persons[8],Function=Function.GUITARIST},
                    new SongPerson{Song=songs[29],Person=persons[9],Function=Function.DRUMMER},
                    new SongPerson{Song=songs[29],Person=persons[10],Function=Function.PRODUCER},

                    new SongPerson{Song=songs[30],Person=persons[12],Function=Function.SINGER | Function.SONGWRITER},
                    new SongPerson{Song=songs[30],Person=persons[13],Function=Function.SONGWRITER | Function.SINGER | Function.GUITARIST },
                    new SongPerson{Song=songs[30],Person=persons[14],Function=Function.BASSIST},
                    new SongPerson{Song=songs[30],Person=persons[15],Function=Function.DRUMMER},
                    new SongPerson{Song=songs[30],Person=persons[16],Function=Function.PRODUCER | Function.COMPOSER},
                    new SongPerson{Song=songs[31],Person=persons[12],Function=Function.SINGER | Function.SONGWRITER},
                    new SongPerson{Song=songs[31],Person=persons[13],Function=Function.SONGWRITER | Function.GUITARIST },
                    new SongPerson{Song=songs[31],Person=persons[14],Function=Function.BASSIST},
                    new SongPerson{Song=songs[31],Person=persons[15],Function=Function.DRUMMER},
                    new SongPerson{Song=songs[31],Person=persons[16],Function=Function.PRODUCER | Function.COMPOSER},
                    new SongPerson{Song=songs[32],Person=persons[12],Function=Function.SINGER | Function.SONGWRITER},
                    new SongPerson{Song=songs[32],Person=persons[13],Function=Function.SONGWRITER | Function.GUITARIST },
                    new SongPerson{Song=songs[32],Person=persons[14],Function=Function.BASSIST},
                    new SongPerson{Song=songs[32],Person=persons[15],Function=Function.DRUMMER},
                    new SongPerson{Song=songs[32],Person=persons[17],Function=Function.PRODUCER | Function.COMPOSER},
                    new SongPerson{Song=songs[33],Person=persons[12],Function=Function.SINGER | Function.SONGWRITER},
                    new SongPerson{Song=songs[33],Person=persons[13],Function=Function.SONGWRITER | Function.GUITARIST },
                    new SongPerson{Song=songs[33],Person=persons[14],Function=Function.BASSIST},
                    new SongPerson{Song=songs[33],Person=persons[15],Function=Function.DRUMMER},
                    new SongPerson{Song=songs[33],Person=persons[16],Function=Function.PRODUCER | Function.COMPOSER},
                    new SongPerson{Song=songs[33],Person=persons[17],Function=Function.PRODUCER},
                    new SongPerson{Song=songs[34],Person=persons[12],Function=Function.SINGER | Function.SONGWRITER},
                    new SongPerson{Song=songs[34],Person=persons[13],Function=Function.SONGWRITER | Function.GUITARIST },
                    new SongPerson{Song=songs[34],Person=persons[14],Function=Function.BASSIST},
                    new SongPerson{Song=songs[34],Person=persons[15],Function=Function.DRUMMER},
                    new SongPerson{Song=songs[34],Person=persons[16],Function=Function.PRODUCER | Function.COMPOSER},
                    new SongPerson{Song=songs[35],Person=persons[12],Function=Function.SINGER | Function.SONGWRITER},
                    new SongPerson{Song=songs[35],Person=persons[13],Function=Function.SONGWRITER | Function.GUITARIST },
                    new SongPerson{Song=songs[35],Person=persons[14],Function=Function.BASSIST},
                    new SongPerson{Song=songs[35],Person=persons[15],Function=Function.DRUMMER},
                    new SongPerson{Song=songs[35],Person=persons[16],Function=Function.PRODUCER | Function.COMPOSER},
                    new SongPerson{Song=songs[36],Person=persons[12],Function=Function.SINGER | Function.SONGWRITER},
                    new SongPerson{Song=songs[36],Person=persons[13],Function=Function.SONGWRITER | Function.GUITARIST },
                    new SongPerson{Song=songs[36],Person=persons[14],Function=Function.BASSIST},
                    new SongPerson{Song=songs[36],Person=persons[15],Function=Function.DRUMMER},
                    new SongPerson{Song=songs[36],Person=persons[16],Function=Function.PRODUCER | Function.COMPOSER},
                    new SongPerson{Song=songs[36],Person=persons[17],Function=Function.PRODUCER},
                    new SongPerson{Song=songs[37],Person=persons[12],Function=Function.SINGER | Function.SONGWRITER},
                    new SongPerson{Song=songs[37],Person=persons[13],Function=Function.SONGWRITER | Function.GUITARIST },
                    new SongPerson{Song=songs[37],Person=persons[14],Function=Function.BASSIST},
                    new SongPerson{Song=songs[37],Person=persons[15],Function=Function.DRUMMER},
                    new SongPerson{Song=songs[37],Person=persons[16],Function=Function.PRODUCER | Function.COMPOSER},
                    new SongPerson{Song=songs[37],Person=persons[17],Function=Function.PRODUCER},
                    new SongPerson{Song=songs[38],Person=persons[12],Function=Function.SINGER | Function.SONGWRITER},
                    new SongPerson{Song=songs[38],Person=persons[13],Function=Function.SONGWRITER | Function.GUITARIST },
                    new SongPerson{Song=songs[38],Person=persons[14],Function=Function.BASSIST},
                    new SongPerson{Song=songs[38],Person=persons[15],Function=Function.DRUMMER},
                    new SongPerson{Song=songs[38],Person=persons[16],Function=Function.PRODUCER | Function.COMPOSER},
                    new SongPerson{Song=songs[39],Person=persons[12],Function=Function.SINGER | Function.SONGWRITER},
                    new SongPerson{Song=songs[39],Person=persons[13],Function=Function.SONGWRITER | Function.GUITARIST },
                    new SongPerson{Song=songs[39],Person=persons[14],Function=Function.BASSIST},
                    new SongPerson{Song=songs[39],Person=persons[15],Function=Function.DRUMMER},
                    new SongPerson{Song=songs[39],Person=persons[16],Function=Function.PRODUCER | Function.COMPOSER},
                    new SongPerson{Song=songs[39],Person=persons[17],Function=Function.PRODUCER},
                    new SongPerson{Song=songs[40],Person=persons[12],Function=Function.SINGER | Function.SONGWRITER},
                    new SongPerson{Song=songs[40],Person=persons[13],Function=Function.SONGWRITER | Function.GUITARIST },
                    new SongPerson{Song=songs[40],Person=persons[14],Function=Function.BASSIST},
                    new SongPerson{Song=songs[40],Person=persons[15],Function=Function.DRUMMER},
                    new SongPerson{Song=songs[40],Person=persons[16],Function=Function.PRODUCER | Function.COMPOSER},
                    new SongPerson{Song=songs[40],Person=persons[17],Function=Function.PRODUCER},
                    new SongPerson{Song=songs[41],Person=persons[12],Function=Function.SINGER | Function.SONGWRITER},
                    new SongPerson{Song=songs[41],Person=persons[13],Function=Function.SONGWRITER | Function.GUITARIST },
                    new SongPerson{Song=songs[41],Person=persons[14],Function=Function.BASSIST},
                    new SongPerson{Song=songs[41],Person=persons[15],Function=Function.DRUMMER},
                    new SongPerson{Song=songs[41],Person=persons[16],Function=Function.PRODUCER | Function.COMPOSER},
                    new SongPerson{Song=songs[42],Person=persons[12],Function=Function.SINGER | Function.SONGWRITER},
                    new SongPerson{Song=songs[42],Person=persons[13],Function=Function.SONGWRITER | Function.GUITARIST },
                    new SongPerson{Song=songs[42],Person=persons[14],Function=Function.BASSIST},
                    new SongPerson{Song=songs[42],Person=persons[15],Function=Function.DRUMMER},
                    new SongPerson{Song=songs[42],Person=persons[16],Function=Function.PRODUCER | Function.COMPOSER},
                    new SongPerson{Song=songs[42],Person=persons[17],Function=Function.PRODUCER},
                    new SongPerson{Song=songs[43],Person=persons[12],Function=Function.SINGER | Function.SONGWRITER},
                    new SongPerson{Song=songs[43],Person=persons[13],Function=Function.SONGWRITER | Function.GUITARIST },
                    new SongPerson{Song=songs[43],Person=persons[14],Function=Function.BASSIST},
                    new SongPerson{Song=songs[43],Person=persons[15],Function=Function.DRUMMER},
                    new SongPerson{Song=songs[43],Person=persons[16],Function=Function.PRODUCER | Function.COMPOSER},
                    new SongPerson{Song=songs[44],Person=persons[12],Function=Function.SINGER | Function.SONGWRITER},
                    new SongPerson{Song=songs[44],Person=persons[13],Function=Function.SONGWRITER | Function.GUITARIST },
                    new SongPerson{Song=songs[44],Person=persons[14],Function=Function.BASSIST},
                    new SongPerson{Song=songs[44],Person=persons[15],Function=Function.DRUMMER},
                    new SongPerson{Song=songs[44],Person=persons[16],Function=Function.PRODUCER | Function.COMPOSER},
                    new SongPerson{Song=songs[44],Person=persons[17],Function=Function.PRODUCER},
                    new SongPerson{Song=songs[45],Person=persons[12],Function=Function.SINGER | Function.SONGWRITER},
                    new SongPerson{Song=songs[45],Person=persons[13],Function=Function.SONGWRITER | Function.GUITARIST },
                    new SongPerson{Song=songs[45],Person=persons[14],Function=Function.BASSIST},
                    new SongPerson{Song=songs[45],Person=persons[15],Function=Function.DRUMMER},
                    new SongPerson{Song=songs[45],Person=persons[16],Function=Function.PRODUCER | Function.COMPOSER},



                    //The Beatles
                    new SongPerson{Song=songs[13],Person=persons[18],Function=Function.PERFORMER},
                    new SongPerson{Song=songs[14],Person=persons[18],Function=Function.PERFORMER},
                    new SongPerson{Song=songs[15],Person=persons[18],Function=Function.PERFORMER},
                    new SongPerson{Song=songs[16],Person=persons[18],Function=Function.PERFORMER},
                    new SongPerson{Song=songs[17],Person=persons[18],Function=Function.PERFORMER},
                    new SongPerson{Song=songs[18],Person=persons[18],Function=Function.PERFORMER},
                    new SongPerson{Song=songs[19],Person=persons[18],Function=Function.PERFORMER},
                    new SongPerson{Song=songs[20],Person=persons[18],Function=Function.PERFORMER},
                    new SongPerson{Song=songs[21],Person=persons[18],Function=Function.PERFORMER},
                    new SongPerson{Song=songs[22],Person=persons[18],Function=Function.PERFORMER},
                    new SongPerson{Song=songs[23],Person=persons[18],Function=Function.PERFORMER},
                    new SongPerson{Song=songs[24],Person=persons[18],Function=Function.PERFORMER},
                    new SongPerson{Song=songs[25],Person=persons[18],Function=Function.PERFORMER},
                    new SongPerson{Song=songs[26],Person=persons[18],Function=Function.PERFORMER},
                    new SongPerson{Song=songs[27],Person=persons[18],Function=Function.PERFORMER},
                    new SongPerson{Song=songs[28],Person=persons[18],Function=Function.PERFORMER},
                    new SongPerson{Song=songs[29],Person=persons[18],Function=Function.PERFORMER},

                    //The Smiths
                    new SongPerson{Song=songs[30],Person=persons[19],Function=Function.PERFORMER},
                    new SongPerson{Song=songs[31],Person=persons[19],Function=Function.PERFORMER},
                    new SongPerson{Song=songs[32],Person=persons[19],Function=Function.PERFORMER},
                    new SongPerson{Song=songs[33],Person=persons[19],Function=Function.PERFORMER},
                    new SongPerson{Song=songs[34],Person=persons[19],Function=Function.PERFORMER},
                    new SongPerson{Song=songs[35],Person=persons[19],Function=Function.PERFORMER},
                    new SongPerson{Song=songs[36],Person=persons[19],Function=Function.PERFORMER},
                    new SongPerson{Song=songs[37],Person=persons[19],Function=Function.PERFORMER},
                    new SongPerson{Song=songs[38],Person=persons[19],Function=Function.PERFORMER},
                    new SongPerson{Song=songs[39],Person=persons[19],Function=Function.PERFORMER},
                    new SongPerson{Song=songs[40],Person=persons[19],Function=Function.PERFORMER},
                    new SongPerson{Song=songs[41],Person=persons[19],Function=Function.PERFORMER},
                    new SongPerson{Song=songs[42],Person=persons[19],Function=Function.PERFORMER},
                    new SongPerson{Song=songs[43],Person=persons[19],Function=Function.PERFORMER},
                    new SongPerson{Song=songs[44],Person=persons[19],Function=Function.PERFORMER},
                    new SongPerson{Song=songs[45],Person=persons[19],Function=Function.PERFORMER}

                };

                context.SongPerson.AddRange(songPersons);
                context.SaveChanges();

                if (context.City.Any())
                {
                    return;
                }
                var cities = new[]
                {
                   new City {PostCode=10000,CityName="Zagreb",Country=countries[0]},
                   new City {PostCode=21000,CityName="Split",Country=countries[0]},
                   new City {PostCode=51000,CityName="Rijeka",Country=countries[0]},
                   new City {PostCode=31000,CityName="Osijek",Country=countries[0]},
                   new City {PostCode=23000,CityName="Zadar",Country=countries[0]},
                   new City {PostCode=22000,CityName="Šibenik",Country=countries[0]},
                   new City {PostCode=20000,CityName="Dubrovnik",Country=countries[0]},
                   new City {PostCode=52210,CityName="Rovinj",Country=countries[0]},

                   new City {PostCode=71000,CityName="Sarajevo",Country=countries[1]},
                   new City {PostCode=75000,CityName="Tuzla",Country=countries[1]},
                   new City {PostCode=88000,CityName="Mostar",Country=countries[1]},
                   new City {PostCode=78000,CityName="Banja Luka",Country=countries[1]},
                   new City {PostCode=77000,CityName="Bihać",Country=countries[1]},

                   new City {PostCode=3000,CityName="Celje",Country=countries[2]},
                   new City {PostCode=8251,CityName="Čatež ob Savi",Country=countries[2]},
                   new City {PostCode=1000,CityName="Ljubljana",Country=countries[2]},
                   new City {PostCode=2000,CityName="Maribor",Country=countries[2]},
                   new City {PostCode=8000,CityName="Novo Mesto",Country=countries[2]}

               };
                context.City.AddRange(cities);
                context.SaveChanges();

                countries[0].Cities.Add(cities[0]);
                countries[0].Cities.Add(cities[1]);
                countries[0].Cities.Add(cities[2]);
                countries[0].Cities.Add(cities[3]);
                countries[0].Cities.Add(cities[4]);
                countries[0].Cities.Add(cities[5]);
                countries[0].Cities.Add(cities[6]);
                countries[0].Cities.Add(cities[7]);

                countries[1].Cities.Add(cities[8]);
                countries[1].Cities.Add(cities[9]);
                countries[1].Cities.Add(cities[10]);
                countries[1].Cities.Add(cities[11]);
                countries[1].Cities.Add(cities[12]);

                countries[2].Cities.Add(cities[13]);
                countries[2].Cities.Add(cities[14]);
                countries[2].Cities.Add(cities[15]);
                countries[2].Cities.Add(cities[16]);
                countries[2].Cities.Add(cities[17]);

                context.SaveChanges();


            }
        }
    }
}

