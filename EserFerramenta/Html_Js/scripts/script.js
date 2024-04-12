const stampaTabella = () => {
    $.ajax(
        {
            url: "https://localhost:7279/api/prodotti",
            type: "GET",
            success: function(risultato){
                let contenuto = "";

                for(let [idx, item] of risultato.entries()){
                    contenuto += `
                        <tr>
                            <td>${item.nome}</td>
                            <td>${item.descrizione}</td>
                            <td>${item.prezzo}</td>
                            <td>
                            <button class="btn btn-primary" type="button" id="decrement">-</button>
                            ${item.quantita}
                            <button class="btn btn-secondary" type="button" id="increment">+</button>
                            </td>
                            <td>${item.categoria}</td>
                            <td>${item.data_aggiunta}</td>
                            <td>
                                <button class="btn btn-warning" onclick="modifica('${item.codice}')">Modifica</button>
                            </td>
                            <td>
                                <button class="btn btn-danger" onclick="elimina('${item.codice}')">Elimina</button>
                            </td>
                        </tr>
                    `;
                }

                $("#corpo-tabella").html(contenuto);
            }, 
            error: function(errore){
                alert("Molto Mario");
                console.log(errore)
            }
        }
    );
}

const elimina = (codice) => {
    
    $.ajax(
        {
            url: "https://localhost:7279/api/prodotti/codice/" + codice,
            type: "POST",
            success: function(){
                alert("Riuscito");
                stampaTabella();
            },
            error: function(errore){
                alert("Molto Mario");
                console.log(errore);
            }
        }
    )

}

const salvaElemento = () => {
    let nome = $("#input-nome").val();
    let desc = $("#input-descrizione").val();
    let prez = $("#input-prezzo").val();
    let quan = $("#input-quantita").val();
    let cate = $("#input-categoria").val();
    let data = $("#input-data").val();

    $.ajax(
        {
            url: "https://localhost:7279/api/prodotti",
            type: "POST",
            data: JSON.stringify({
                nome: nome,
                descrizione: desc,
                prezzo: prez,
                quantita: quan,
                categoria: cate,
                data : data
            }),
            contentType: "application/json",
            dataType: "json",
            success: function(){
                alert("Riuscito");
                stampaTabella();
            },
            error: function(errore){
                alert("Molto Mario");
                console.log(errore);
            }
        
        }
    )
}

$(document).ready(
    function(){

        stampaTabella();

        $(".salva").on("click", () => {
            salvaElemento();
        })

    }
);