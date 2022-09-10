import { Materijal } from "./materijal.js";

export class Prodavnica{
    constructor(id,naziv,prihod){
        this.id=id,
        this.naziv=naziv,
        this.prihod=prihod,
        this.kontejnter=null
        this.listaMaterijala=[]
        this.cenaKuce=null
    }

    crtaj(host)
    {
        this.kontejnter=host;

        let divProdavnica=document.createElement("div")
        divProdavnica.classList.add("divProdavnica")
        this.kontejnter.appendChild(divProdavnica)
        
        let headerProdavnica=document.createElement("header")
        headerProdavnica.classList.add("headerProdavnica")
        headerProdavnica.classList.add(`headerProdavnica${this.id}`)
        headerProdavnica.innerHTML=`${this.naziv}: ${this.prihod} rsd`
        divProdavnica.appendChild(headerProdavnica)

        let divForma=document.createElement("div")
        divForma.classList.add("divForma")
        divProdavnica.appendChild(divForma)

        let divOpcije=document.createElement("div")
        divOpcije.classList.add("divOpcije")
        divForma.appendChild(divOpcije)

        let divPrikaz=document.createElement("div")
        divPrikaz.classList.add("divPrikaz")
        divForma.appendChild(divPrikaz)

        this.kontejnter=divPrikaz

        this.crtajOpcije(divOpcije)
    }

    crtajOpcije(host)
    {
        let divPodesavanje = document.createElement("div")
        divPodesavanje.classList.add("divPodesavanje")
        host.appendChild(divPodesavanje)

        let divZaLabele = document.createElement("div")
        divZaLabele.classList.add("divZaLabele")
        divPodesavanje.appendChild(divZaLabele)

         let nizLabela=["Kuća","Fasada","Stolarija","Krov"]
         nizLabela.forEach(el=>{
            let l = document.createElement("label")
            l.innerHTML=`${el}:`
            divZaLabele.appendChild(l)
         })

         let divZaSelect=document.createElement("div")
         divZaSelect.classList.add("divZaSelect")
         divPodesavanje.appendChild(divZaSelect)

        let selectKuca = document.createElement("select")
        selectKuca.classList.add("selectkuca")
        let selectFasada = document.createElement("select")
        selectFasada.classList.add("selectfasada")
        let selectStolarija = document.createElement("select")
        selectStolarija.classList.add("selectstolarija")
        let selectKrov = document.createElement("select")
        selectKrov.classList.add("selectkrov")

        divZaSelect.appendChild(selectKuca)
        divZaSelect.appendChild(selectFasada)
        divZaSelect.appendChild(selectStolarija)
        divZaSelect.appendChild(selectKrov)


        let buttonPodesi=document.createElement("button")
        buttonPodesi.classList.add("buttonPodesi")
         
        buttonPodesi.innerHTML="Podesi"

        let divZaButton=document.createElement("div")
        divZaButton.classList.add("divZaButton")
        host.appendChild(divZaButton)

        divZaButton.appendChild(buttonPodesi)

        fetch(`https://localhost:5001/Ispit/PreuzmiMaterijale/${this.id}`,{method:"GET"}).then(s=>{
            s.json().then(data=>{
                data.forEach(el=>{
                    var materijal=new Materijal(el.spojID,el.naziv,el.boja,el.tip,el.cenaMaterijala)
                    materijal.crtaj(divZaSelect)
                    this.listaMaterijala.push(materijal)
                })
                //console.log(this.listaMaterijala)
                buttonPodesi.addEventListener('click',()=>this.crtajKucu(selectKuca,selectFasada,selectKrov,selectStolarija))               
            })
        })
    }
    crtajKucu(selectKuca,selectFasada,selectKrov,selectStolarija)
    {
            this.cenaKuce=this.listaMaterijala.find(el=>el.naziv==selectFasada.value).cena+
            this.listaMaterijala.find(el=>el.naziv==selectKrov.value).cena+
            this.listaMaterijala.find(el=>el.naziv==selectStolarija.value).cena+
            this.listaMaterijala.find(el=>el.naziv==selectKuca.value).cena
            console.log(this.cenaKuce)

            this.obrisiDecu(this.kontejnter)
            
            let divZaKucu=document.createElement("div")
            divZaKucu.classList.add("divZaKucu")
            this.kontejnter.appendChild(divZaKucu)

            let divKucerak=document.createElement("div")
            divKucerak.classList.add("divKucerak")
            divZaKucu.appendChild(divKucerak)

            let labelCena=document.createElement("div")
            labelCena.classList.add("labelCena")
            labelCena.innerHTML=`Cena: ${this.cenaKuce}`
            divZaKucu.appendChild(labelCena)

            let buttonPoruci=document.createElement("button")
            buttonPoruci.classList.add("buttonPoruci")
            buttonPoruci.innerHTML="Poruči"
            buttonPoruci.addEventListener('click',()=>this.naruci())
            divZaKucu.appendChild(buttonPoruci)

            let divKrov=document.createElement("div")
            divKrov.classList.add("divKrov")
            divKrov.style.borderBottom=`100px solid ${this.listaMaterijala.find(el=>el.naziv==selectKrov.value).boja}`;
            divKucerak.appendChild(divKrov)

            let divFasada=document.createElement("div")
            divFasada.classList.add("divFasada")
            divFasada.style.border=`6px solid ${this.listaMaterijala.find(el=>el.naziv==selectFasada.value).boja}`
            divFasada.style.backgroundColor=`${this.listaMaterijala.find(el=>el.naziv==selectKuca.value).boja}`
            divKucerak.appendChild(divFasada)

            let divProzori=document.createElement("div")
            divProzori.classList.add("divProzori")
            divFasada.appendChild(divProzori)

            let divProzoriLevi=document.createElement("div")
            divProzoriLevi.classList.add("divProzoriLevi")
            divProzori.appendChild(divProzoriLevi)

            let divLevoKrilo=document.createElement("div")
            divLevoKrilo.classList.add("divLevoKrilo")
            divLevoKrilo.style.border=`3px solid ${this.listaMaterijala.find(el=>el.naziv==selectStolarija.value).boja}`
            divProzoriLevi.appendChild(divLevoKrilo)

            let divDesnoKrilo=document.createElement("div")
            divDesnoKrilo.classList.add("divDesnoKrilo")
            divDesnoKrilo.style.border=`3px solid ${this.listaMaterijala.find(el=>el.naziv==selectStolarija.value).boja}`
            divProzoriLevi.appendChild(divDesnoKrilo)

            let divProzoriDesni=document.createElement("div")
            divProzoriDesni.classList.add("divProzoriDesni")
            divProzori.appendChild(divProzoriDesni)

            divLevoKrilo=document.createElement("div")
            divLevoKrilo.classList.add("divLevoKrilo")
            divLevoKrilo.style.border=`3px solid ${this.listaMaterijala.find(el=>el.naziv==selectStolarija.value).boja}`
            divProzoriLevi.appendChild(divLevoKrilo)

            divDesnoKrilo=document.createElement("div")
            divDesnoKrilo.classList.add("divDesnoKrilo")
            divDesnoKrilo.style.border=`3px solid ${this.listaMaterijala.find(el=>el.naziv==selectStolarija.value).boja}`
            divProzoriLevi.appendChild(divDesnoKrilo)

            divProzoriDesni.appendChild(divDesnoKrilo)
            divProzoriDesni.appendChild(divLevoKrilo)

            let divZaVrata = document.createElement("div")
            divZaVrata.classList.add("divZaVrata")
            divFasada.appendChild(divZaVrata)

            let divVrata = document.createElement("div")
            divVrata.classList.add("divVrata")
            divVrata.style.border=`3px solid ${this.listaMaterijala.find(el=>el.naziv==selectStolarija.value).boja}`
            divZaVrata.appendChild(divVrata)




            
    }
    naruci(){
        var ime = prompt("Unesite vase ime","Petar")
        var prezime = prompt("Unesite vase prezime","Petrovic")
        console.log(ime,prezime)

        fetch(`https://localhost:5001/Ispit/NapraviKorisnika/${this.id}/${ime}/${prezime}`, //pravim korisnika
        {method:"POST",headers:{'Content-type':'application/json'}}).then(s=>{
            s.json().then(data=>{
                fetch(`https://localhost:5001/Ispit/KupiKucu/${this.id}/${data}/${this.cenaKuce}`,
                {method:"POST",headers:{"Content-type":'application/json'}}).then(s=>{
                    s.text().then(data=>{
                        alert("Uspesno ste kupili kucu")
                        let header = document.querySelector(`.headerProdavnica${this.id}`)
                        this.prihod=data
                        header.innerHTML=`${this.naziv}: ${this.prihod} rsd`
                        this.obrisiDecu(this.kontejnter)
                    })
                })
            })
        })
    }

    obrisiDecu(host)
    {
        while(host.firstChild){
            host.removeChild(host.firstChild)
        }
    }
}