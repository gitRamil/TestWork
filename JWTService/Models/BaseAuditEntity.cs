namespace JWTService.Model;

/// <summary>
/// Базовая сущность с аудитом
/// </summary>
public abstract class BaseAuditEntity : BaseEntity
{
    /// <summary>
    /// Время создания
    /// </summary>
    public DateTime Created { get; set; }

    /// <summary>
    /// Кто создал
    /// </summary>
    public Guid CreatedUserId { get; set; }

    /// <summary>
    /// Время изменения
    /// </summary>
    public DateTime? Modified { get; set; }

    /// <summary>
    /// Кем изменено
    /// </summary>
    public Guid? ModifiedUserId { get; set; }
}