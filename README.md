Uppdrag 7 – Matleveranstjänstens ordersystem 

Kundens problem 

Kunden driver en matleveranstjänst som förmedlar beställningar mellan kunder och flera restauranger, samt tilldelar beställningar till leveranspersonal. En beställning innehåller flera maträtter, ska kunna prisberäknas (inklusive eventuella rabatter eller leveransavgift), och går igenom flera statusar från beställning till leverans. 

Olika restauranger kan ha olika regler för minsta beställningssumma och leveranstid. 

Fundera på 

• Hur representeras en beställning och dess rader (maträtter, antal, pris)? 

• Hur representeras olika restauranger och deras egna regler? 

• Hur beräknas totalpris inklusive eventuell rabatt och leveransavgift? 

• Hur hanteras beställningens status (Mottagen, Tillagas, Ute för leverans, Levererad, Avbruten)? 

• Hur skulle ni tilldela en beställning till en ledig leveransperson? 

• Hur lägger ni till en ny typ av rabatt utan att ändra befintlig prisberäkningskod? 

• Vem tar emot en ny beställning och samordnar flödet vidare, och hur håller ni rabattlogik, orderhantering och tilldelning i separata, fokuserade klasser? 

Exempel på design patterns att överväga: State, Strategy, Observer 

Lämpliga SOLID-principer att fundera på: Hur lägger ni till en ny typ av rabatt eller en ny leveransregel utan att ändra befintlig prisberäkningskod? 

Lämpliga GRASP-principer att fundera på: Vem tar emot en ny beställning och samordnar flödet vidare, och hur håller ni rabattlogik, orderhantering och tilldelning i separata, fokuserade klasser? 
