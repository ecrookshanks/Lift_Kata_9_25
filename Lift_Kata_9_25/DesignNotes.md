# Design Notes for this rendition of the Lift Kata

## From the Kata site:
starting with simple behaviors and working toward complex ones. Assume good input from calling code and concentrate on the main flow.

Here are some suggested lift features:

a lift responds to calls containing a source floor and direction
a lift has an attribute floor, which describes it’s current location
a lift delivers passengers to requested floors
you may implement current floor monitor
you may implement direction arrows
you may implement doors (opening and closing)
you may implement DING!
there can be more than one lift
### Advanced Requirements
a lift does not respond immediately. consider options to simulate time, possibly a tick method.
lift calls are queued, and executed only as the lift passes a floor

## Notes
* The first set of tests only test an individual lift (car) and whether or not it has the correct status, accepts requests, 
and moves in the right direction.
* The second set of tests should test the input from the user once inside the lift.
* Additionally, a lift can accumulate multiple requests if it is "convenient".
* The second set of tests should introduce a "Dispatcher" that acts as a coordinator for an entire lift system.
* The interactions of the Lift(s) and the Dispatcher should be implemented using events.
