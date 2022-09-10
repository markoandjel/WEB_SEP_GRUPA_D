import { Prodavnica } from "./prodavnica.js";

fetch("https://localhost:5001/Ispit/PreuzmiProdavnice",{method:"GET"})
.then(s=>{
    s.json().then(data=>{
        data.forEach(element => {
            var prodavnica=new Prodavnica(element.id,element.naziv,element.prihod)
            prodavnica.crtaj(document.body)
        });
    })
})