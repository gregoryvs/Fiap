// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuriReceitasng this project to bundle and minify static web assets.

// Write your JavaScript code.

const uriReceitas = 'api/Receita';
let todos = [];

function getReceitas() {
  fetch(uriReceitas)
    .then(response => response.json())
    .then(data => _displayReceitas(data))
    .catch(error => console.error('Unable to get Receitas.', error));
}

function addReceita() {
  //const addImagemFile = document.getElementById('add-imagem');
  const addTituloTextbox = document.getElementById('add-titulo');
  const addCategoriaTextbox = document.getElementById('add-categoria');
  const addDescricaoTextbox = document.getElementById('add-descricao');
  const addModoDePreparoTextbox = document.getElementById('add-mododepreparo');

  
  debugger;
  const receita = {
    //foto: addImagemFile,
    titulo: addTituloTextbox.value.trim(),
    categoria: addCategoriaTextbox.value.trim(),
    descricao: addDescricaoTextbox.value.trim(),
    mododepreparo: addModoDePreparoTextbox.value.trim()
  };

  fetch(uriReceitas, {
    method: 'POST',
    headers: {
      'Accept': 'application/json',
      'Content-Type': 'application/json'
    },
    body: JSON.stringify(receita)
  })
    .then(response => response.json())
    .then(() => {
      getReceitas();
      addTituloTextbox.value = '';
      addDescricaoTextbox.value = '';
      addModoDePreparoTextbox.value = '';
      //addImagemFile.value = '';
      addCategoriaTextbox.value = '';
    })
    .catch(error => console.error('Unable to add item.', error));
}

function deleteItem(id) {
  fetch(`${uriReceitas}/${id}`, {
    method: 'DELETE'
  })
  .then(() => getReceitas())
  .catch(error => console.error('Unable to delete item.', error));
}

function displayEditForm(id) {
  const receita = todos.find(receita => receita.id === id);
  
  document.getElementById('edit-id').value = receita.id;
  document.getElementById('edit-titulo').value = receita.titulo;
  document.getElementById('edit-categoria').value = receita.categoria;
  document.getElementById('edit-descricao').value = receita.descricao;
  document.getElementById('edit-mododepreparo').value = receita.modoDePreparo;
  document.getElementById('editForm').style.display = 'block';
}

function updateReceita() {
  debugger;
  const receitaId = document.getElementById('edit-id').value;
  const receita = {
    id: parseInt(receitaId, 10),
    titulo: document.getElementById('edit-titulo').value.trim(),
    categoria: document.getElementById('edit-categoria').value.trim(),
    descricao: document.getElementById('edit-descricao').value.trim(),
    mododepreparo: document.getElementById('edit-mododepreparo').value.trim()
  };

  fetch(`${uriReceitas}/${receitaId}`, {
    method: 'PUT',
    headers: {
      'Accept': 'application/json',
      'Content-Type': 'application/json'
    },
    body: JSON.stringify(receita)
  })
  .then(() => getReceitas())
  .catch(error => console.error('Unable to delete item.', error));

  closeInput();

  return false;
}

function closeInput() {
  document.getElementById('editForm').style.display = 'none';
}

function _displayCount(itemCount) {
  const name = (itemCount === 1) ? 'Receita' : 'Receitas';

  document.getElementById('counter').innerText = `${itemCount} ${name}`;
}

function _displayReceitas(data) {
  const tBody = document.getElementById('todos');
  tBody.innerHTML = '';

  _displayCount(data.length);

  const button = document.createElement('button');

  data.forEach(item => {

    let editButton = button.cloneNode(false);
    editButton.innerText = 'Editar';
    editButton.setAttribute('onclick', `displayEditForm(${item.id})`);

    let deleteButton = button.cloneNode(false);
    deleteButton.innerText = 'Apagar';
    deleteButton.setAttribute('onclick', `deleteItem(${item.id})`);

    let tr = tBody.insertRow();
    let td1 = tr.insertCell(0);
    td1.innerHTML = '<div class="blog-entry align-self-stretch d-md-flex"> ' 
                  + ' <a class="block-20" asp-area="" style="background-image: url(image_1.jpg);" asp-controller="Home" asp-action="Details">Privacy </a>'
                  + ' <div class="text d-block pl-md-4">'
                  + ' <div class="meta mb-3">'
                  + ' <div><a href="#"> ' + item.dataDeCadastro + ' </a></div>'
                  + ' </div>'
                  + ' <h3 class="heading"><a href="#"> ' + item.titulo + ' </a></h3>'
                  + ' <p> Categoria:' + item.categoria + ' </p>'
                  + ' <p> Descrição:' + item.descricao + ' </p>'
                  + ' <p>  </p>'
                  + ' <p> Modo de Preparo:' + item.modoDePreparo + ' </p>'
                  + ' </div>'
                  + ' </div>';

    let td4 = tr.insertCell(1);
    td4.appendChild(editButton);

    let td5 = tr.insertCell(2);
    td5.appendChild(deleteButton);

  });

  todos = data;
}