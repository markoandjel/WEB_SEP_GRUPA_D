export class Materijal{
    constructor(id,naziv,boja,tip,cena){
        this.id=id,
        this.naziv=naziv,
        this.boja=boja,
        this.tip=tip,
        this.cena=cena
    }

    crtaj(host)
    {
        let select=host.querySelector(`.select${this.tip}`)
        let option=document.createElement("option")
        option.innerHTML=this.naziv
        option.value=this.naziv
        select.appendChild(option)
    }
}