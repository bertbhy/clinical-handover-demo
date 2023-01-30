
--            var sqlFile = Directory.GetCurrentDirectory() + @"\Resources\historyTable.sql"; 
--            migrationBuilder.Sql(File.ReadAllText(sqlFile));
--            migrationBuilder.Sql("EXEC sp_fill_history");
CREATE OR ALTER PROCEDURE sp_fill_history as
begin
exec('
ALTER TABLE 
  dbo.handover 
SET 
  (SYSTEM_VERSIONING = OFF);
ALTER TABLE dbo.handover DROP PERIOD FOR SYSTEM_TIME;
')
exec('
TRUNCATE table [dbo].[HandoverHistory] 
INSERT INTO [dbo].[HandoverHistory] (
    [id], [patientKey], [patientName], 
    [dob], [sex], [wardCode], [specialtyCode], 
    [bedNumber], [admissionTime], [caseNumber], 
    [freeText], [diagnosis], [background], 
    [progress], [ix], [drugs], [recommendation], 
    [editedBy], [GroupId], 
    [PeriodEnd], [PeriodStart]
  ) 
select 
  h.[id], [patientKey], [patientName], 
  [dob], [sex], [wardCode], [specialtyCode], 
  [bedNumber], [admissionTime], [caseNumber], 
  [freeText], [diagnosis], [background], 
  [progress], [ix], [drugs], [recommendation], 
  [editedBy], [GroupId], 
  DATEADD(second,3, logtime), 
  DATEADD(second,-2, logtime) 
from 
  handover H 
  inner join HandoverLogs L on L.Handoverid = H.id 

update 
  h 
set 
  PeriodStart = DATEADD(second,4, logtime), 
  PeriodEnd = CONVERT(
    DATETIME2, ''9999-12-31 23:59:59.9999999''
  ) 
from 
  handover H 
  inner join HandoverLogs L on L.Handoverid = H.id 
')
exec('
ALTER TABLE handover ADD PERIOD FOR SYSTEM_TIME (PeriodStart, PeriodEnd) 
ALTER TABLE 
  handover 
SET 
  (
    SYSTEM_VERSIONING = ON (
      HISTORY_TABLE = dbo.[HandoverHistory], 
      DATA_CONSISTENCY_CHECK = ON
    )
  );
')
end
