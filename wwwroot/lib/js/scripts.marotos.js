function excluirCategoria(nomeCategoria, idCategoria)
{
	if(confirm('Deseja realmente excluir a categoria '+nomeCategoria+'?')) {
		var jqxhr = $.post( "http://localhost:57600/Categorias/DeleteViaAjax/",
		{
			id: idCategoria
		},

		function() {
		  
		})
		  .done(function() {
			alert( "Categoria excluída com sucesso" );
			location.reload();
		  })
		  .fail(function() {
			alert( "Problemas ao executar a exclusão." );
		  })
		  .always(function() {
			alert( "finished" );
		  });

	} 
	
	
}