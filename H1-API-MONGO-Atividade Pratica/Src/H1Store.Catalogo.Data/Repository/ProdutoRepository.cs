﻿using AutoMapper;
using H1Store.Catalogo.Data.Providers.MongoDb.Collections;
using H1Store.Catalogo.Data.Providers.MongoDb.Interfaces;
using H1Store.Catalogo.Domain.Entities;
using H1Store.Catalogo.Domain.Interfaces;
using MongoDB.Bson;
using MongoDB.Driver;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H1Store.Catalogo.Data.Repository
{
	public class ProdutoRepository : IProdutoRepository
	{
		private readonly IMongoRepository<ProdutoCollection> _produtoRepository;
		private readonly IMapper _mapper;

		#region - Construtores
		public ProdutoRepository(IMongoRepository<ProdutoCollection> produtoRepository, IMapper mapper)
		{
			_produtoRepository = produtoRepository;
			_mapper = mapper;
		}
		#endregion

		#region - Funções
		public async Task Adicionar(Produto produto)
		{		
			await _produtoRepository.InsertOneAsync(_mapper.Map<ProdutoCollection>(produto));
		}

		public async Task Atualizar(Produto produto)
		{ 

			var buscaProduto = await _produtoRepository.FindOneAsync(filter => filter.CodigoId == produto.CodigoId);
			var prod = _mapper.Map<ProdutoCollection>(produto);
			prod.Id = buscaProduto.Id;
			await _produtoRepository.ReplaceOneAsync(prod);
		}

		public async Task Desativar(Produto produto)
		{
			var buscaProduto = await _produtoRepository.FindOneAsync(filter => filter.CodigoId == produto.CodigoId);
			buscaProduto.Ativo = produto.Ativo;
			await _produtoRepository.ReplaceOneAsync(buscaProduto);
		}

		public async Task Ativar(Produto produto)
		{
			var buscaProduto = await _produtoRepository.FindOneAsync(prod => prod.CodigoId == produto.CodigoId);
			buscaProduto.Ativo = produto.Ativo;
			await _produtoRepository.ReplaceOneAsync(buscaProduto);
		}

		public async Task AlterarPreco(Produto produto, decimal newPreco)
		{
			var busca_produto = await _produtoRepository.FindOneAsync(prod => prod.CodigoId == produto.CodigoId);
			busca_produto.Valor = newPreco;
			await _produtoRepository.ReplaceOneAsync(busca_produto);
		}

		public async Task AtualizarEstoque(Produto produto)
		{
			var busca_produto = await _produtoRepository.FindOneAsync(prod => prod.CodigoId == produto.CodigoId);
			busca_produto.QuantidadeEstoque = produto.QuantidadeEstoque;
			await _produtoRepository.ReplaceOneAsync(busca_produto);
		}

		public async Task<IEnumerable<Produto>> ObterPorCategoria(int codigo)
		{
			throw new NotImplementedException();
		}

		public async Task<Produto> ObterPorId(Guid id)
		{

			var buscaProduto = await _produtoRepository.FindOneAsync(prod => prod.CodigoId == id);
			var produto = _mapper.Map<Produto>(buscaProduto);
			return produto;
		}

		public async Task<Produto> ObterPorNome(string nome)
		{
			var buscaProduto = await _produtoRepository.FindOneAsync(prod => prod.Nome.Contains(nome));
			return _mapper.Map<Produto>(buscaProduto);
		}

		public IEnumerable<Produto> ObterTodos()
		{
			var produtoList = _produtoRepository.FilterBy(filter => true);

			return _mapper.Map<IEnumerable<Produto>>(produtoList);

		}
		#endregion

	}
}
