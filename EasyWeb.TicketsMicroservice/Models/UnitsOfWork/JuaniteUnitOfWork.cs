using EasyWeb.TicketsMicroservice.Models.Context;
using EasyWeb.TicketsMicroservice.Models.Dtos.EntityDto;
using EasyWeb.TicketsMicroservice.Models.Entities;
using EasyWeb.TicketsMicroservice.Models.Repositories;

namespace EasyWeb.TicketsMicroservice.Models.UnitsOfWork
{
    public sealed class JuaniteUnitOfWork
    {
        #region Miembros privados

        /// <summary>
        ///     Contexto de acceso a la base de datos
        /// </summary>
        private readonly TicketsDbContext _context;

        /// <summary>
        ///     Logger de la aplicación
        /// </summary>
        private readonly ILogger _logger;

        #region Repositorios

        /// <summary>
        ///     Repositorio de incidencias
        /// </summary>
        private JuaniteRepository<Ticket> _ticketsRepository;

        /// <summary>
        ///     Repositorio de mensajes
        /// </summary>

        private JuaniteRepository<Message> _messagesRepository;

        /// <summary>
        ///     Repositorio de archivos adjuntos
        /// </summary>
        private JuaniteRepository<Attachment> _attachmentsRepository;

        /// <summary>
        ///     Repositorio de incidencias + nombre de técnico
        /// </summary>
        private JuaniteRepository<TicketUserDto> _ticketUserRepository;

        #endregion

        #endregion

        #region Propiedades públicas

        /// <summary>
        ///     Repositorio de incidencias
        /// </summary>
        public JuaniteRepository<Ticket> TicketsRepository => _ticketsRepository ?? (_ticketsRepository = new JuaniteRepository<Ticket>(_context, _logger));

        /// <summary>
        ///     Repositorio de mensajes
        /// </summary>
        public JuaniteRepository<Message> MessagesRepository => _messagesRepository ?? (_messagesRepository = new JuaniteRepository<Message>(_context, _logger));

        /// <summary>
        ///     Repositorio de archivos adjuntos
        /// </summary>
        public JuaniteRepository<Attachment> AttachmentsRepository => _attachmentsRepository ?? (_attachmentsRepository = new JuaniteRepository<Attachment>(_context, _logger));

        /// <summary>
        ///     Repositorio de incidencias + nombre de técnico
        /// </summary>
        public JuaniteRepository<TicketUserDto> TicketUserRepository => _ticketUserRepository ?? (_ticketUserRepository = new JuaniteRepository<TicketUserDto>(_context, _logger));

        #endregion

        #region Constructores

        /// <summary>
        ///     Constructor por defecto
        /// </summary>
        /// <param name="logger"><see cref="ILogger"/></param>
        /// <param name="context"><see cref="TicketsDbContext"/></param>
        public JuaniteUnitOfWork(ILogger logger, TicketsDbContext context)
        {
            _context = context;
            _logger = logger;
        }

        #endregion

        #region Métodos públicos

        /// <summary>
        ///     Guarda los cambios pendientes en los contextos de base de datos
        /// </summary>
        /// <returns></returns>
        public async Task SaveChanges()
        {
            await _context.SaveChangesAsync();
        }

        #endregion
    }
}
