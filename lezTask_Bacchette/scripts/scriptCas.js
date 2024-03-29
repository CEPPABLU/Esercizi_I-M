const stampa = () => {
    let elenco = JSON.parse( localStorage.getItem('casate_ol') );

    let stringaTab = '';
    for(let [idx, item] of elenco.entries()){
        stringaTab += `
            <tr>
                <td>${idx + 1}</td>
                <td>${item.cod}</td>
                <td>${item.mat}</td>
                <td>${item.nucl}</td>
                <td>${item.lung}</td>
                <td>${item.res}</td>
                <td>${item.prop}</td>
                <td>${item.cas}</td>
                <td class="text-right">
                    <button class="btn btn-outline-warning" onclick="modifica(${idx})">
                        <i class="fa-solid fa-pencil"></i>
                    </button>
                    <button class="btn btn-outline-danger" onclick="elimina(${idx})">
                        <i class="fa-solid fa-trash"></i>
                    </button>
                </td>
            </tr>
        `;
    }

    document.getElementById("corpo-tabella").innerHTML = stringaTab;
}

const salva = () => {
    let cod = document.getElementById("input-codice").value;
    let mat = document.getElementById("input-materiale").value;
    let nucl = document.getElementById("input-nucleo").value;
    let lung = document.getElementById("input-lunghezza").value;
    let res = document.getElementById("input-resistenza").value;
    let prop = document.getElementById("input-proprietario").value;
    let cas = document.getElementById("select-casata").value;

    let bacc = {
        cod,
        mat,
        nucl,
        lung,
        res,
        prop,
        cas,
    }

    let elenco = JSON.parse( localStorage.getItem('casate_ol') ); 
    elenco.push(bacc);                                               
    localStorage.setItem('casate_ol', JSON.stringify(elenco));    

    document.getElementById("input-codice").value = "";
    document.getElementById("input-materiale").value = "";
    document.getElementById("input-nucleo").value = "";
    document.getElementById("input-lunghezza").value = "";
    document.getElementById("input-resistenza").value = "";
    document.getElementById("input-proprietario").value = "";
    document.getElementById("select-casata").value = "";

    stampa();

    $("#modaleInserimento").modal("hide");
}

const elimina = (indice) => {
    let elenco = JSON.parse( localStorage.getItem('casate_ol') );
    elenco.splice(indice, 1);
    localStorage.setItem('casate_ol', JSON.stringify(elenco));

    stampa();
}

const modifica = (indice) => {

    let elenco = JSON.parse( localStorage.getItem('casate_ol') );
    console.log(elenco[indice])

    document.getElementById("update-nome").value = elenco[indice].nome;
    document.getElementById("update-descrizione").value = elenco[indice].desc;
    document.getElementById("update-prezzo").value = elenco[indice].prez;
    document.getElementById("update-categoria").value = elenco[indice].cate;
    document.getElementById("update-categoria").value = elenco[indice].cate;
    document.getElementById("update-categoria").value = elenco[indice].cate;
    document.getElementById("update-categoria").value = elenco[indice].cate;

    $("#modaleModifica").data("identificativo", indice)

    $("#modaleModifica").modal("show");
}

const update = () => {
    let cod = document.getElementById("input-codice").value;
    let mat = document.getElementById("input-materiale").value;
    let nucl = document.getElementById("input-nucleo").value;
    let lung = document.getElementById("input-lunghezza").value;
    let res = document.getElementById("input-resistenza").value;
    let prop = document.getElementById("input-proprietario").value;
    let cas = document.getElementById("select-casata").value;

    let bacc = {
        cod,
        mat,
        nucl,
        lung,
        res,
        prop,
        cas,
    }

    let indice = $("#modaleModifica").data("identificativo")

    let elenco = JSON.parse( localStorage.getItem('casate_ol') );
    elenco[indice] = bacc;
    localStorage.setItem('casate_ol', JSON.stringify(elenco));

    $("#modaleModifica").modal("hide");
}


//Creazione elenco se non esiste
let elencoString = localStorage.getItem('casate_ol');
if(!elencoString)
    localStorage.setItem('casate_ol', JSON.stringify([]) );

setInterval(() => {
    stampa(); 
}, 1000);

stampa(); 