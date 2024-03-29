﻿using DataAccessLibrary.DataContext;
using DataAccessLibrary.Entity;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Layer
{
    public class TransactionManager
    {
        private User user;
        private DBOperations dBOperations;

        public Account senderAccount;
        public Account receiverAccount;


        public TransactionManager(ref User user,DBOperations dBOperations)
        {
            this.user = user;
            this.dBOperations = dBOperations;
        }

        public bool MakeTransaction(Account senderAccount, Account receiverAccount, string name, float amount)
        {
            if (name.IsNullOrEmpty())
            {
                name = $"Transaction between {senderAccount.AccountName} and {receiverAccount.AccountName} ";
            }

          return dBOperations.Transaction(senderAccount, receiverAccount, name, amount);
        }

        public List<Transaction> GetUserSearchedTransactionsAll(string search)
        {
            return dBOperations.GetUserSearchedTransactionsAll(user, search);
        }

        public List<Transaction> GetUserSearchedTransactionsSent(string search)
        {
            return dBOperations.GetUserSearchedTransactionsSent(user, search);
        }

        public List<Transaction> GetUserSearchedTransactionsReceived(string search)
        {
            return dBOperations.GetUserSearchedTransactionsReceived(user, search);
        }

        public List<Transaction> GetUserTransactions()
        {
            return dBOperations.GetUserTransactions(user);
        }

        public List<Transaction> GetUserSentTransactions()
        {
            return dBOperations.GetUserSentTransactions(user);
        }

        public List<Transaction> GetUserReceivedTransactions ()
        {
            return dBOperations.GetUserReceivedTransactions(user);
        }

        public List<Transaction> GetAccountTransactions(Account account)
        {
            return dBOperations.GetAccountTransactions(account);
        }

        public List<Transaction> GetAccountSentTransactions(Account account)
        {
            return dBOperations.GetAccountSentTransactions(account);
        }

        public List<Transaction> GetAccountReceivedTransactions(Account account)
        {
            return dBOperations.GetAccountReceivedTransactions(account);
        }

        public List<Transaction> GetAccountSearchedTransactionsAll(Account account,string search)
        {
            return dBOperations.GetAccountSearchedTransactionsAll(account,search);
        }

        public List<Transaction> GetAccountSearchedTransactionsSent(Account account,string search)
        {
            return dBOperations.GetAccountSearchedTransactionsSent(account, search);
        }

        public List<Transaction> GetAccountSearchedTransactionsReceived(Account account,string search)
        {
            return dBOperations.GetAccountSearchedTransactionsReceived(account, search);
        }

        public void ResetSenderReceiverAccounts()
        {
            senderAccount = null;
            receiverAccount = null;
        }

    }
}
