-- Delete all of the data
DELETE FROM reservation
DELETE FROM [site]
DELETE FROM campground
DELETE FROM park

-- Insert a fake park
INSERT INTO park VALUES ('Yellowstone', 'Wyoming', '1872-03-01', 8983, 4116524, 'Beautiful and old park in Wyoming.');
DECLARE @newParkId int = (SELECT @@IDENTITY);

-- Insert a fake campground
INSERT INTO campground VALUES(@newParkId, 'Grant Village Campground', 6, 12, 30.00)
DECLARE @newCampgroundId int = (SELECT @@IDENTITY);

-- Insert a fake site
INSERT INTO site VALUES (@newCampgroundId, 8, 30, 0, 0, 0);
DECLARE @newSiteId int = (SELECT @@IDENTITY);

-- Insert a fake reservation
INSERT INTO reservation VALUES (@newSiteId, 'Tech Elevator Group Outing', '2019-07-15', '2019-07-24', GETDATE());
DEClARE @newReservationId int = (SELECT @@IDENTITY);

-- Return the id of the fake inserts
SELECT @newParkId AS newParkId, @newCampgroundId AS newCampgroundId, @newSiteId AS newSiteId, @newReservationId AS newReservationId