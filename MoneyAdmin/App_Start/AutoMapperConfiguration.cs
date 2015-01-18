using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using MoneyAdmin.Data.Entities;
using MoneyAdmin.ViewModel;

namespace MoneyAdmin
{
	public static class AutoMapperConfiguration
	{
        public static IMappingExpression<TTo, TFrom> Back<TFrom, TTo>(this IMappingExpression<TFrom, TTo> expression)
	    {
	        return Mapper.CreateMap<TTo, TFrom>();
	    }

	    public static void Configure()
	    {
	        Mapper.CreateMap<User, UserViewModel>().Back();
            Mapper.CreateMap<User, LoginViewModel>().Back();

            Mapper.CreateMap<Wallet, WalletViewModel>().Back();
            Mapper.CreateMap<Transaction, TransactionViewModel>().Back();
            Mapper.CreateMap<Category, CategoryViewModel>().Back();
	    }
	}
}