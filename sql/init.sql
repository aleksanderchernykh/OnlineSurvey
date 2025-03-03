CREATE EXTENSION IF NOT EXISTS "uuid-ossp";

DO $$
BEGIN
  IF NOT EXISTS (SELECT 1 FROM pg_tables WHERE tablename = 'survey') THEN
    CREATE TABLE Survey (
        Id UUID PRIMARY KEY DEFAULT uuid_generate_v4(),
        Title VARCHAR(255) NOT NULL,
        Description TEXT,
        IsActive BOOLEAN NOT NULL
    );

    CREATE INDEX idx_survey_isactive ON Survey (IsActive);
    CREATE INDEX idx_survey_id_isactive ON Survey (Id, IsActive);

    CREATE TABLE Question (
        Id UUID PRIMARY KEY DEFAULT uuid_generate_v4(),
        SurveyId UUID NOT NULL,
        QuestionText TEXT NOT NULL,
        QuestionOrder INT NOT NULL,
        CONSTRAINT fk_question_survey FOREIGN KEY (SurveyId) REFERENCES Survey(Id) ON DELETE CASCADE
    );

    CREATE INDEX idx_question_surveyid ON Question (SurveyId);
    CREATE INDEX idx_question_surveyid_order ON Question (SurveyId, QuestionOrder);

    CREATE TABLE Answer (
        Id UUID PRIMARY KEY DEFAULT uuid_generate_v4(),
        QuestionId UUID NOT NULL,
        AnswerText TEXT NOT NULL,
        AnswerOrder INT NOT NULL,
        CONSTRAINT fk_answer_question FOREIGN KEY (QuestionId) REFERENCES Question(Id) ON DELETE CASCADE
    );

    CREATE INDEX idx_answer_questionid ON Answer (QuestionId);

    CREATE TABLE Interview (
        Id UUID PRIMARY KEY DEFAULT uuid_generate_v4(),
        SurveyId UUID NOT NULL,
        FullName VARCHAR(255) NOT NULL,
        Age INT,
        CONSTRAINT fk_interview_survey FOREIGN KEY (SurveyId) REFERENCES Survey(Id) ON DELETE CASCADE
    );

    CREATE INDEX idx_interview_surveyid ON Interview (SurveyId);
    CREATE INDEX idx_interview_surveyid_fullname ON Interview (SurveyId, FullName);

    CREATE TABLE Result (
        Id UUID PRIMARY KEY DEFAULT uuid_generate_v4(),
        InterviewId UUID NOT NULL,
        QuestionId UUID NOT NULL,
        AnswerId UUID,
        CONSTRAINT fk_result_interview FOREIGN KEY (InterviewId) REFERENCES Interview(Id) ON DELETE CASCADE,
        CONSTRAINT fk_result_question FOREIGN KEY (QuestionId) REFERENCES Question(Id) ON DELETE CASCADE,
        CONSTRAINT fk_result_answer FOREIGN KEY (AnswerId) REFERENCES Answer(Id) ON DELETE CASCADE
    );

    CREATE INDEX idx_result_interviewid ON Result (InterviewId);

    RAISE NOTICE 'Таблицы созданы';
  ELSE
    RAISE NOTICE 'Таблицы уже существуют';
  END IF;
END
$$;