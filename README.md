
# Applied Programming Project 1 : Color Depth reduction

## Inhoudstabel

1. [Start van het project](#Start)
2. [Gebruik van het project](#Gebruik)
3. [Algoritmes](#Algoritmes)
4. [Graphical User interface](#GUI)
5. [Code](#Code)
6. [Bronnen](#Bronnen)

## Start

Ik ben gestart met allereest goed de powerpoints te lezen om de opdracht goed door te hebben. Dan heb ik een lijst gemaakt met ongeveer alle elementen die ik dacht nodig te hebben:

1. Foto uploaden in .jpg, .jpeg, .png, .gif en .bmp oftewel een imageformat
2. De geüploade foto weergeven op het scherm
3. bewerkingen uitvoeren op geüploade foto
4. bewerkte foto weergeven naast orinele foto
5. een kleurenpallet weergeven
6. foto met bewerkingen opslaan als .gif bestand op schijf.

Ik ben wat beginnen opzoeken rond hoe al deze dingen zouden kunnen in C# en stootte direct op een aantal interessante websites en voorbeelden, zie [bronnen](#bronnen).

Dan ben ik de [GUI](#GUI) beginnen ontwerpen in zijn alle basis. Een paar knoppen voor de basis functionaliteiten, zoals een afbeelding uploaden, bewerken met 1 algoritme en een knop om op te slaan als gif.

Dan was het tijd om deze basis functies om te zetten in code en dat heb ik dan dus ook gedaan. zie [code](#code).

## Gebruik

Hier volgen stappen om de converter te gebruiken.

1. open de applicatie
2. Druk op de knop met "Browse for an image" om een foto te kiezen die je zal bewerken.
3. Je krijgt nu van alle info op het scherm over de originele foto te zien.
4. In het midden bevind zich een drop down lijst met keuze tussen verschillende [algoritmes](#algoritmes)
5. Klik het juiste algoritme uit de lijst aan, de foto rechts op het scherm zal automatisch aanpassen naar een versie met het gekozen algoritme.
6. Als je de bewerkte foto wilt opslaan, kan je op de knop "Save result" duwen. Geef de gewenste naam en locatie in.
7. Als je nog een foto wil converteren, kan je op de knop "convert another image" duwen, anders sluit je het programma af.

## Algoritmes

Hier is een lijst met de algoritmes die ik gebruikte en waarom:

### UniformAlgorithm

Dit algoritme is een van de eerste. Het is een redelijk speciale aanpak. Elke kleurcomponent(rood, groen, blauw en alpha) zijn onderverdeeld in nieuwe segmenten.
Elke kleur wordt in een bijhorend segment geplaatst, nadat alle kleuren zijn toegevoegd, wordt de gemiddelde kleur per segment bepaald. Dat zijn de kleuren die het pallet zal gebruiken.

***pro***

- Zeer snel
- Kleine opslagruimte
- Verbruikt weinig geheugen

***contra***

- Slechte kwaliteit
- Kan enkel met 256 kleuren werken

### PopularityAlgorithm

Dit algoritme is van dezelfde familie als het uniform quantization algoritme. In dit algoritme wordt eerst het originele pallet onderverdeeld in 4x4x4 kubussen, dan worden die kleuren ook onderverdeeld in regios, nadat alle kleuren verdeeld zijn, worden de regios met meeste pixels gecalculeerd naar het gemiddelde, enzovoort.

***pro***

- Kleine opslagruimte
- Verbruikt weinig geheugen

***contra***

- Slechte kwaliteit bij bestanden met heel veel kleuren

### AtkinsonDithering

Dit algoritme is van dezelfde aard als Jarvis dithering of Sierra dithering. Het algoritme diffuseert maar slechts driekwart van het bestand waardoor het heel snel is. Het heeft de neiging om details goed te bewaren,maar lichte en donkere gebieden kunnen nogal vaag lijken.

***pro***

- Zeer snelle dithering
- Verbruikt weinig geheugen

***contra***

- Slechte kwaliteit in donkere of lichte kleuren

## GUI

Ik ben begonnen met de GUI. De GUI hoeft helemaal niet ingewikkeld te zijn. Een uploadknop, info over de afbeelding, een keuze van het algoritme, een knop om de originele afbeelding om te zetten en een knop om de nieuwe afbeelding op te slaan.

Dus dat heb ik gedaan. Ondertussen kwamen er natuurlijk nog ideetjes op hoe ik de GUI er beter kan laten uitzien en gemakkelijker te gebruiken kan maken. Ik heb onder andere enkel de beschikbare acties zichtbaar gemaakt. Zo kan er weinig foutlopen bij het gebruik van de GUI. Dat zorgt ervoor dat ik minder error-handling moet toepassen en de GUI er simpel uitziet.

## Code

### MainForm.cs

Dit is de [GUI](#GUI) van de applicatie.
De GUI bestaat uit een knop om een foto toe te voegen, een PictureBox voor de originele image, een PictureBox voor de bewerkte image, een keuze om een [bewerkingsalgoritme](#algoritmes) te berekenen, en nog wat randinformatie zoals de dimenties van de originele image en de [color distance](#colordistance.cs). In de MainForm.cs staat eigenlijk teveel code die gemoeid is met Quantizers. Dit komt omdat ik daarmee begonnen ben en eigenlijk te weinig OO gewerkt heb. Op het einde van het project vond ik mijn eigen code nogal ingewikkeld om alles te verplaatsen naar [QuantizationHelper.cs](#QuantizationHelper.cs).

### Helpers

In deze map zitten helper klassen die worden gebruikt om data weer te geven of om data om te zetten en weer mee te geven aan andere klassen.

#### ColorDistance.cs

Deze klasse genereert een double die de colordistance weergeeft. Deze wordt berekend door 2 images mee te geven en alle pixels te vergelijken met elkaar en daar het gemiddelde van te nemen.

#### DitherHelper.cs

Deze klasse maakt de foto klaar om te ditheren en om te zetten naar Bitmap.

#### GetPalette.cs

Deze klasse geeft een Bitmap met het kleurenpallet terug om te weergeven op de GUI

#### QuantizationHelper.cs

Deze klasse beheert het kleurenpallet voor- en nadat de bitmap omgezet wordt van kleur

### Quantizers

In deze map zitten alle klassen die algoritmes bevatten om bewerkingen te maken op de originele image.

#### Popularity

zie [Popularity Algorithm](#PopularityAlgorithm)

#### Uniform

zie [Uniform Algorithm](#UniformAlgorithm)

### Ditherers

#### DitheringBase.cs

Deze klasse geeft de foto door naar de eigenlijke methode voor dithering. Deze klasse zou vooral gemakkelijk zijn indien je meer dithering algoritmes zou willen.

#### AtkinsonDithering.cs

zie [Akinson Dithering](#AtkinsonDithering)

## Bronnen

1. <https://www.graphicsmill.com/docs/gm/color-reduction-basics.htm#targetText=Dithering%20is%20an%20algorithm%20class,pixels%20in%20a%20special%20way.>
2. <https://www.andrewhoefling.com/Blog/Post/basic-image-manipulation-in-c-sharp>
3. <https://rosettacode.org/wiki/Color_quantization>
4. <https://www.codeproject.com/Articles/66341/A-Simple-Yet-Quite-Powerful-Palette-Quantizer-in-C>
5. <https://docs.microsoft.com/en-us/dotnet/api/>
6. <https://en.wikipedia.org/wiki/Dither>
7. <https://www.tutorialspoint.com/dip/concept_of_dithering.htm>
8. <https://github.com/mcraiha/CSharp-Dithering>
