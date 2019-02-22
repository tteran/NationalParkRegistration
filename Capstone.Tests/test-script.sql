-- Delete all of the data
DELETE FROM park;
DELETE FROM campground;
DELETE FROM site;
DELETE FROM reservation;

-- Insert a fake reservation.
--INSERT INTO reservation VALUES();
DECLARE @new_reservation_id int = (SELECT @@IDENTITY);