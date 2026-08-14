# WFHTracker UX Principles

> **Status:** Authoritative  
> **Purpose:** User experience principles for WFHTracker  
> **Audience:** Developers, Copilot, and anyone designing or modifying the application

---

## 1. Purpose

WFHTracker exists to make tracking work-from-home activity simple.

The user's primary goals are straightforward:

- Record work-from-home activity.
- Understand their accumulated activity.
- See their estimated tax deduction.
- Correct or remove entries when necessary.
- Quickly understand what they need to do next.

The application should never make these tasks feel more complicated than they need to be.

---

# 2. Core UX Philosophy

## Make the obvious thing easy

The interface should make the user's next action apparent.

Users should not need to:

- Read extensive instructions
- Explore menus to discover basic functionality
- Understand the application's internal structure
- Interpret technical terminology

If an action is important, make it visible and understandable.

---

## Simple before clever

When two interaction patterns can accomplish the same goal, prefer the simpler one.

Avoid introducing:

- Unnecessary steps
- Hidden interactions
- Complex workflows
- Novel controls
- Excessive configuration

The application should favour familiarity over novelty.

---

# 3. Minimise Cognitive Load

Every interaction requires some mental effort.

WFHTracker should minimise that effort.

Users should not have to remember information that the application can reasonably remember or display.

For example:

- Show relevant totals rather than making users calculate them.
- Preserve previously entered information where appropriate.
- Use sensible defaults.
- Explain unfamiliar concepts at the point they are encountered.
- Keep related information together.

---

# 4. One Primary Purpose Per Screen

Each screen should have a clear primary purpose.

Users should be able to answer:

> "What am I supposed to do here?"

quickly.

Avoid screens that attempt to:

- Enter data
- Configure settings
- Explain tax rules
- Display detailed history
- Present unrelated information

all at the same time.

Secondary functionality should support the primary purpose rather than compete with it.

---

# 5. Make Important Information Obvious

WFHTracker contains information that matters to the user.

Important information should not be hidden behind unnecessary interactions.

Examples include:

- Current WFH totals
- Hours worked
- Estimated deduction
- Selected dates
- Current reporting period

The user should be able to understand the important numbers without having to interpret the interface.

---

# 6. Progressive Disclosure

Not all information needs to be shown at once.

Show the information necessary for the current task first.

Provide additional detail when the user needs it.

For example:

**Primary information**

> Estimated deduction: $1,245

**Additional information**

> Based on 415 hours using the ATO fixed-rate method.

This keeps the interface approachable without preventing users from understanding the calculation.

---

# 7. Reduce Data Entry

Users should enter only information that is genuinely required.

Where information can be:

- Calculated
- Derived
- Remembered
- Defaulted

consider doing so.

Avoid asking users to enter the same information repeatedly.

Every unnecessary field increases friction.

---

# 8. Sensible Defaults

Defaults should reduce effort without making assumptions that could create incorrect results.

Good defaults may include:

- Today's date
- Previously selected options
- Common values
- The user's most recent selections

Defaults should remain easy to change.

Never silently assume information that could materially affect a user's tax calculation.

---

# 9. Immediate Feedback

Users should receive clear feedback after meaningful actions.

Examples:

- Entry successfully saved.
- Entry deleted.
- Calculation updated.
- Data could not be saved.

Feedback should confirm what happened without becoming intrusive.

Avoid unnecessary notifications for trivial interactions.

---

# 10. Errors Are Part of the UX

Errors should help users recover.

An error message should answer:

1. What went wrong?
2. What can the user do about it?

Prefer:

> We couldn't save your entry. Please try again.

over:

> Error 500.

Where possible, preserve the user's entered information so they do not have to start again.

---

# 11. Validation

Validation should occur at the appropriate point in the workflow.

Do not make users submit an entire form only to discover obvious input errors.

Validation messages should:

- Identify the affected field
- Explain the problem
- Suggest the correction where useful
- Use plain language

Avoid technical validation messages.

---

# 12. Don't Make Users Think

Interfaces should minimise unnecessary decision-making.

Avoid presenting users with multiple choices when there is an obvious recommended path.

For example, if there is one normal way to add a WFH entry, provide:

> Add WFH entry

rather than making the user choose between several unnecessarily different workflows.

---

# 13. Clear Action Hierarchy

Each interaction should have a clear primary action.

For example:

> Save entry

should be visually and behaviourally more prominent than:

> Cancel

Users should not have to determine which of several equally prominent buttons they should press.

---

# 14. Destructive Actions

Actions such as deleting an entry should require appropriate caution.

The interface should make it clear:

- What will be deleted
- That the action is destructive
- Whether the action can be undone

Do not make destructive actions visually or behaviourally identical to normal actions.

Avoid unnecessary confirmation dialogs for actions that are easily reversible.

---

# 15. Preserve User Context

When users navigate through the application, avoid unnecessarily losing their context.

For example:

- Preserve relevant selections.
- Return users to sensible locations after an action.
- Avoid unexpectedly resetting forms.
- Avoid navigating users away from their current task without a clear reason.

Users should feel that the application remembers where they are.

---

# 16. Explain Rather Than Assume

WFHTracker includes concepts that may not be obvious to every user.

Where clarification is necessary, provide it at the point of need.

Do not force users to leave the application and search elsewhere for basic explanations.

Keep explanations concise.

---

# 17. Tax Information Requires Particular Care

WFHTracker provides estimates relating to Australian work-from-home tax deductions.

The application should distinguish clearly between:

> **An estimate**

and:

> **A guaranteed tax outcome**

Calculations should be presented transparently enough that users can understand what the estimate represents.

Where appropriate, explain:

- Which method is being used
- What the calculation is based on
- Relevant assumptions
- That the result is an estimate

Do not present tax estimates with unjustified certainty.

---

# 18. Transparency in Calculations

A user should be able to understand where an important number came from.

For example:

> Estimated deduction: $1,245

should, where appropriate, be supported by information such as:

> 415 eligible hours × applicable fixed rate

The goal is not to expose implementation details.

The goal is to give users confidence in the result.

---

# 19. Don't Hide Complexity in the Wrong Place

The application itself may contain technically complex code.

Users should not need to understand that complexity.

Keep technical complexity behind the interface.

However, don't simplify information to the point where the result becomes misleading.

The UX should be simple without being deceptive.

---

# 20. Consistency

Similar actions should work in similar ways.

For example:

- Buttons should behave consistently.
- Forms should validate consistently.
- Errors should be communicated consistently.
- Navigation should behave predictably.
- Similar data should be presented using similar patterns.

Once a user learns how one part of WFHTracker works, that knowledge should transfer to other parts of the application.

---

# 21. Don't Surprise the User

Avoid unexpected behaviour.

Examples of poor surprises include:

- Data disappearing unexpectedly
- Forms resetting without explanation
- Navigation changing unexpectedly
- Actions happening without user intent
- Important information appearing only after an unrelated action

When something significant happens, make it clear.

---

# 22. Respect User Control

Users should feel in control of their data.

They should be able to:

- Add entries
- Review entries
- Correct entries
- Delete entries
- Understand what the application is calculating

Do not make users fight the interface to correct an error.

---

# 23. Mobile Is Not a Secondary Experience

WFHTracker should work naturally on mobile devices.

Mobile users should not have to:

- Zoom excessively
- Horizontally scroll through normal content
- Use tiny controls
- Navigate desktop-oriented layouts
- Perform unnecessarily complicated interactions

Where the desktop and mobile experiences need to differ, optimise each for its context rather than forcing identical layouts.

Responsive layouts should adapt spacing as well as structure.

Mobile should use available screen width efficiently, while larger screens should introduce additional whitespace and visual breathing room.

Do not assume that the same horizontal padding value is appropriate at every breakpoint.

---

# 24. Accessibility Is UX

Accessibility should be considered part of normal UX design.

The application should work for users who:

- Navigate with a keyboard
- Use assistive technologies
- Have visual impairments
- Have motor limitations
- Have difficulty interpreting colour alone

Accessibility improvements should not be treated as separate from good design.

---

# 25. Loading and Waiting

Users should understand when the application is working.

Avoid situations where the interface appears frozen or unresponsive.

Loading states should:

- Appear when an operation takes noticeable time
- Communicate what is happening when useful
- Avoid unnecessary animation
- Prevent accidental duplicate actions where appropriate

Do not display loading indicators for operations so fast that the indicator itself becomes distracting.

---

# 26. Empty States Should Have Purpose

An empty state should explain what the user is seeing and, where appropriate, what they can do next.

Poor:

> No data.

Better:

> No WFH entries yet.

Best when appropriate:

> No WFH entries yet. Add your first entry to start tracking your hours.

An empty screen should not feel like a dead end.

---

# 27. Don't Over-Notify

Not every action needs a toast, alert or confirmation message.

Too many notifications reduce the importance of meaningful feedback.

Use notifications when they provide useful confirmation or information.

Prefer quiet state changes when the result is already obvious.

---

# 28. Avoid Unnecessary Features

A feature should exist because it solves a real user problem.

Do not add functionality simply because:

- Other applications have it
- It looks impressive
- It fills empty space
- It is technically interesting
- It is easy to implement

The question should always be:

> Does this make WFHTracker more useful?

---

# 29. Avoid Dashboard Bloat

A dashboard should summarise useful information.

It should not become a collection of every metric the application can calculate.

Every metric should justify its presence.

Prioritise:

1. What the user needs now
2. What the user checks frequently
3. What helps the user make a decision

Deprioritise information that is technically interesting but rarely useful.

---

# 30. User Trust

WFHTracker deals with personal work and financial information.

The UX should therefore communicate reliability.

Trust comes from:

- Clear calculations
- Predictable behaviour
- Honest wording
- Consistent interfaces
- Appropriate error handling
- Transparent assumptions
- No misleading claims

Avoid interfaces that feel manipulative or overly promotional.

---

# 31. Privacy and Security UX

Users should understand when their data is being saved, loaded or unavailable.

Do not expose technical implementation details unnecessarily.

If a security or authentication issue affects the user's ability to use the application, explain the situation in user-friendly language.

Do not silently fail.

---

# 32. Performance Is Part of UX

A technically functional application can still provide a poor experience if it feels slow.

Prefer:

- Fast initial rendering
- Efficient data loading
- Appropriate loading states
- Avoiding unnecessary network requests
- Avoiding unnecessary re-rendering

Do not sacrifice maintainability for premature optimisation.

---

# 33. Interaction Before Decoration

When choosing between:

- Improving an interaction
- Adding decorative visual elements

prioritise the interaction.

A better workflow is more valuable than a prettier screen.

---

# 34. Design for the Real Task

Always consider what the user is actually trying to accomplish.

For example, the user is not really trying to:

> "Enter a date, number of hours and location."

They are trying to:

> "Record that I worked from home."

The interface should be designed around the user's goal rather than the application's underlying data model.

---

# 35. Don't Expose the Data Model

The application's database or API structure should not dictate the UX.

A user should not have to understand concepts such as:

- Records
- Entities
- DTOs
- API requests
- Storage containers
- Database identifiers

The interface should use language based on the user's mental model.

---

# 36. Progressive Complexity

Start simple.

Only introduce additional complexity when the user needs it.

For example:

```text
Simple task
    ↓
Basic information
    ↓
Optional detail
    ↓
Advanced information
```

Do not present advanced functionality before it becomes relevant.

---

# 37. Recovery Over Punishment

When something goes wrong, help the user recover.

Prefer:

> Try again

over forcing the user to:

- Restart the workflow
- Reload the application
- Re-enter information
- Navigate back several screens

Where recovery is possible, make it easy.

---

# 38. Avoid Dead Ends

Every major workflow should have a sensible next step.

Examples:

After adding an entry:

> View entries  
> Add another entry

After an empty state:

> Add your first entry

After an error:

> Try again

Users should rarely reach a screen where they have no idea what to do next.

---

# 39. User Mental Model

The application should match how users naturally think about working from home.

Users think in terms of:

- Days
- Hours
- Work periods
- Totals
- Tax estimates

The interface should use those concepts rather than exposing internal technical structures.

---

# 40. Decision Framework

When making a UX decision, ask these questions in order:

### 1. What is the user trying to accomplish?

Start with the user's goal.

### 2. What is the simplest way to support that goal?

Avoid unnecessary steps.

### 3. What information does the user actually need?

Do not overwhelm them.

### 4. What could go wrong?

Design recovery paths.

### 5. What should happen next?

Make the next action clear.

### 6. Does this behave consistently with the rest of WFHTracker?

Reuse established patterns.

### 7. Does it work on mobile and for accessible use?

If not, it is not finished.

---

# 41. UX North Star

When uncertain about a UX decision, ask:

> **Would a first-time user understand what to do without needing us to explain it?**

If yes, the design is probably on the right track.

If the answer is no, simplify the interaction before adding more instructions.

---

# 42. Final Principle

WFHTracker should not require users to learn how WFHTracker works.

It should simply help them accomplish what they came to do.

The ideal experience is:

> **Open it. Understand it. Do the thing. Move on.**

That is the WFHTracker UX.