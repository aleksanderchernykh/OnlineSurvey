using Microsoft.EntityFrameworkCore;
using OnlineSurvey.Infrastructure.Models;

namespace OnlineSurvey.Infrastructure.Data;

public partial class OnlineSurveyContext : DbContext
{
    public OnlineSurveyContext()
    {
    }

    public OnlineSurveyContext(DbContextOptions<OnlineSurveyContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Answer> Answers { get; set; }

    public virtual DbSet<Interview> Interviews { get; set; }

    public virtual DbSet<Question> Questions { get; set; }

    public virtual DbSet<Result> Results { get; set; }

    public virtual DbSet<Survey> Surveys { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasPostgresExtension("uuid-ossp");

        modelBuilder.Entity<Answer>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("answer_pkey");

            entity.ToTable("answer");

            entity.HasIndex(e => e.QuestionId, "idx_answer_questionid");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("uuid_generate_v4()")
                .HasColumnName("id");
            entity.Property(e => e.AnswerOrder).HasColumnName("answerorder");
            entity.Property(e => e.AnswerText).HasColumnName("answertext");
            entity.Property(e => e.QuestionId).HasColumnName("questionid");

            entity.HasOne(d => d.Question).WithMany(p => p.Answers)
                .HasForeignKey(d => d.QuestionId)
                .HasConstraintName("fk_answer_question");
        });

        modelBuilder.Entity<Interview>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("interview_pkey");

            entity.ToTable("interview");

            entity.HasIndex(e => e.SurveyId, "idx_interview_surveyid");

            entity.HasIndex(e => new { e.SurveyId, e.Fullname }, "idx_interview_surveyid_fullname");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("uuid_generate_v4()")
                .HasColumnName("id");
            entity.Property(e => e.Age).HasColumnName("age");
            entity.Property(e => e.Fullname)
                .HasMaxLength(255)
                .HasColumnName("fullname");
            entity.Property(e => e.SurveyId).HasColumnName("surveyid");

            entity.HasOne(d => d.Survey).WithMany(p => p.Interviews)
                .HasForeignKey(d => d.SurveyId)
                .HasConstraintName("fk_interview_survey");
        });

        modelBuilder.Entity<Question>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("question_pkey");

            entity.ToTable("question");

            entity.HasIndex(e => e.SurveyId, "idx_question_surveyid");

            entity.HasIndex(e => new { e.SurveyId, e.QuestionOrder }, "idx_question_surveyid_order");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("uuid_generate_v4()")
                .HasColumnName("id");
            entity.Property(e => e.QuestionOrder).HasColumnName("questionorder");
            entity.Property(e => e.QuestionText).HasColumnName("questiontext");
            entity.Property(e => e.SurveyId).HasColumnName("surveyid");

            entity.HasOne(d => d.Survey).WithMany(p => p.Questions)
                .HasForeignKey(d => d.SurveyId)
                .HasConstraintName("fk_question_survey");
        });

        modelBuilder.Entity<Result>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("result_pkey");

            entity.ToTable("result");

            entity.HasIndex(e => e.InterviewId, "idx_result_interviewid");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("uuid_generate_v4()")
                .HasColumnName("id");
            entity.Property(e => e.AnswerId).HasColumnName("answerid");
            entity.Property(e => e.InterviewId).HasColumnName("interviewid");
            entity.Property(e => e.QuestionId).HasColumnName("questionid");

            entity.HasOne(d => d.Answer).WithMany(p => p.Results)
                .HasForeignKey(d => d.AnswerId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("fk_result_answer");

            entity.HasOne(d => d.Interview).WithMany(p => p.Results)
                .HasForeignKey(d => d.InterviewId)
                .HasConstraintName("fk_result_interview");

            entity.HasOne(d => d.Question).WithMany(p => p.Results)
                .HasForeignKey(d => d.QuestionId)
                .HasConstraintName("fk_result_question");
        });

        modelBuilder.Entity<Survey>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("survey_pkey");

            entity.ToTable("survey");

            entity.HasIndex(e => new { e.Id, e.IsActive }, "idx_survey_id_isactive");

            entity.HasIndex(e => e.IsActive, "idx_survey_isactive");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("uuid_generate_v4()")
                .HasColumnName("id");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.IsActive).HasColumnName("isactive");
            entity.Property(e => e.Title)
                .HasMaxLength(255)
                .HasColumnName("title");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
