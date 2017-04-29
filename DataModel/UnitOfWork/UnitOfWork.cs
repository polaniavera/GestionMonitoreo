#region Using Namespaces...

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Data.Entity.Validation;
using DataModel.GenericRepository;

#endregion

namespace DataModel.UnitOfWork
{
    /// <summary>
    /// Unit of Work class responsible for DB transactions
    /// </summary>
    public class UnitOfWork : IUnitOfWork
    {
        #region Private member variables...

        private MonitoreoDbEntities _context = null;
        private GenericRepository<Registro> _registroRepository;
        private GenericRepository<Usuario> _usuarioRepository;
        private GenericRepository<Item> _itemRepository;
        private GenericRepository<Documento> _documentoRepository;
        private RegistroCustomRepository _registroCustomRepository; 
        #endregion

        public UnitOfWork()
        {
            _context = new MonitoreoDbEntities();
        }

        #region Public Repository Creation properties...

        /// <summary>
        /// Get/Set Property for registro repository.
        /// </summary>
        public GenericRepository<Registro> RegistroRepository
        {
            get
            {
                if (this._registroRepository == null)
                    this._registroRepository = new GenericRepository<Registro>(_context);
                return _registroRepository;
            }
        }

        /// <summary>
        /// Get/Set Property for usuario repository.
        /// </summary>
        public GenericRepository<Usuario> UsuarioRepository
        {
            get
            {
                if (this._usuarioRepository == null)
                    this._usuarioRepository = new GenericRepository<Usuario>(_context);
                return _usuarioRepository;
            }
        }

        /// <summary>
        /// Get/Set Property for item repository.
        /// </summary>
        public GenericRepository<Item> ItemRepository
        {
            get
            {
                if (this._itemRepository == null)
                    this._itemRepository = new GenericRepository<Item>(_context);
                return _itemRepository;
            }
        }

        /// <summary>
        /// Get/Set Property for documento repository.
        /// </summary>
        public GenericRepository<Documento> DocumentoRepository
        {
            get
            {
                if (this._documentoRepository == null)
                    this._documentoRepository = new GenericRepository<Documento>(_context);
                return _documentoRepository;
            }
        }

        /// <summary>
        /// Get/Set Property for registro repository custom.
        /// </summary>
        public RegistroCustomRepository RegistroCustomRepository
        {
            get
            {
                if (this._registroCustomRepository == null)
                    this._registroCustomRepository = new RegistroCustomRepository(_context);
                return _registroCustomRepository;
            }
        }

        #endregion

        #region Public member methods...
        
        /// <summary>
        /// Save method.
        /// </summary>
        public void Save()
        {
            try
            {
                _context.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {

                var outputLines = new List<string>();
                foreach (var eve in e.EntityValidationErrors)
                {
                    outputLines.Add(string.Format(
                        "{0}: Entity of type \"{1}\" in state \"{2}\" has the following validation errors:", DateTime.Now,
                        eve.Entry.Entity.GetType().Name, eve.Entry.State));
                    foreach (var ve in eve.ValidationErrors)
                    {
                        outputLines.Add(string.Format("- Property: \"{0}\", Error: \"{1}\"", ve.PropertyName, ve.ErrorMessage));
                    }
                }
                System.IO.File.AppendAllLines(@"C:\errors.txt", outputLines);

                throw e;
            }

        }

        #endregion

        #region Implementing IDiosposable...

        #region private dispose variable declaration...
        private bool disposed = false;
        #endregion

        /// <summary>
        /// Protected Virtual Dispose method
        /// </summary>
        /// <param name="disposing"></param>
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    Debug.WriteLine("UnitOfWork is being disposed");
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        /// <summary>
        /// Dispose method
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }

}

