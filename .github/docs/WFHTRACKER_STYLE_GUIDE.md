# WFHTracker Style Guide

> **Status:** Authoritative  
> **Purpose:** Visual and UX design reference for WFHTracker  
> **Audience:** Developers, Copilot, and anyone modifying the WFHTracker UI

---

## 1. Purpose

WFHTracker is a simple Australian web application for employees who work from home and want to track their working-from-home days, hours and estimated tax deductions.

The interface should feel:

- Calm
- Clear
- Trustworthy
- Lightweight
- Professional
- Friendly without being childish
- Simple before clever

The application should never feel like an enterprise administration system.

It should feel like a **well-designed, focused utility** that makes one job easy.

---

# 2. Core Design Philosophy

## Simple before clever

> **We build software that is simple before it is clever.**

This is the primary design principle for WFHTracker.

When choosing between two UI approaches:

1. Prefer the simpler one.
2. Prefer the clearer one.
3. Prefer the option requiring less explanation.
4. Prefer established patterns over novel interactions.
5. Avoid adding UI merely because space is available.

Do not add complexity simply to make the interface appear more sophisticated.

---

## Quiet confidence

WFHTracker should communicate confidence without being loud.

Avoid:

- Excessive animations
- Large decorative graphics
- Heavy gradients
- Excessive shadows
- Overly rounded "startup SaaS" interfaces
- Excessive badges
- Unnecessary icons
- Marketing-style copy inside the application
- Visually noisy dashboards

The application should look considered rather than flashy.

---

## Clarity over decoration

Visual elements should communicate something.

If an element does not improve:

- comprehension
- navigation
- feedback
- accessibility
- task completion

then question whether it belongs in the interface.

---

# 3. Brand Relationship

WFHTracker is a DC Digital product.

The product should feel like part of the **DC Digital family**, while retaining its own product identity.

### DC Digital

DC Digital provides the overarching design philosophy:

- Simple
- Thoughtful
- Calm
- Professional
- Human

### WFHTracker

WFHTracker adds a product-specific identity:

- Practical
- Approachable
- Useful
- Organised
- Slightly energetic

The WFHTracker colour identity is therefore more energetic than the neutral DC Digital corporate palette, while the overall design language remains consistent.

---

# 4. Visual Personality

The desired visual impression is:

> **Clean, calm, practical software that feels trustworthy without feeling corporate.**

A user should be able to open the application and immediately understand:

- Where they are
- What they have recorded
- What they can do next
- What the important numbers mean

---

# 5. Colour System

## General principle

Use colour intentionally.

The majority of the interface should use neutral colours.

WFHTracker's orange should act as an **accent**, not as the background for large portions of the application.

Colour should establish hierarchy rather than decoration.

---

## Primary Brand Colour

WFHTracker uses **orange as its primary product accent**.

Use the established WFHTracker orange from the application's existing Tailwind/theme configuration rather than introducing a new shade.

The primary accent is used for:

- Primary buttons
- Important interactive elements
- Selected states
- Key highlights
- Links where appropriate
- Product identity
- Important visual indicators

Do not create additional arbitrary orange shades for individual components.

---

## Neutral Colours

The interface should primarily use neutral tones for:

- Page backgrounds
- Cards
- Panels
- Input backgrounds
- Borders
- Secondary text

The visual language should remain relatively soft rather than using harsh pure black/white combinations everywhere.

Where existing theme tokens are available, **reuse them**.

Do not introduce one-off hex values inside individual components unless there is a specific reason.

---

## Semantic Colours

Semantic colours should be reserved for semantic meaning.

### Success

Used for:

- Successful operations
- Positive confirmations
- Completed actions
- Valid states

### Warning

Used for:

- Important but non-critical information
- Potential issues
- Situations requiring attention

### Error

Used for:

- Validation errors
- Failed operations
- Destructive warnings
- Authentication failures

### Informational

Used for:

- Helpful contextual information
- Explanations
- Non-critical notices

Semantic colours should not be used merely as decorative accents.

---

# 6. Typography

Typography should be clean, modern and highly readable.

## Font

Use the application's established font configuration.

Do not introduce a new font simply for a particular page or component.

Typography should feel consistent throughout the application.

---

## Hierarchy

Use typography to establish a clear hierarchy.

### Page title

Large and confident, but not oversized.

A page title should immediately identify the purpose of the current screen.

### Section heading

Clearly subordinate to the page title.

Used to divide meaningful areas of content.

### Body text

Highly readable and comfortable for extended reading.

### Supporting text

Used for:

- Explanations
- Help text
- Secondary information
- Metadata

Supporting text should remain readable and should not be reduced to excessively small sizes.

---

## Typography principles

Prefer:

- Clear hierarchy
- Moderate font weights
- Comfortable line height
- Short readable paragraphs

Avoid:

- Excessive font-weight changes
- ALL CAPS for normal UI
- Tiny explanatory text
- Huge headings
- Decorative typography

---

# 7. Spacing

WFHTracker should use a consistent spacing system.

Prefer existing Tailwind spacing utilities and established component spacing.

Do not invent arbitrary spacing values for individual components.

---

## General spacing hierarchy

Smaller spacing should be used for related elements.

Larger spacing should separate distinct concepts.

For example:

```text
Label
small gap
Input
small gap
Help text

larger gap

Next field
```

Rather than:

```text
Label
huge gap
Input
tiny gap
Help text
```

---

## Visual breathing room

Do not attempt to fill every available area.

Whitespace is intentional.

Cards and sections should have enough internal padding to feel comfortable without becoming excessively spacious.

---

# 8. Layout

WFHTracker should use a clean application layout with a controlled content width.

Content should not stretch unnecessarily across very wide desktop screens.

The application should feel centred and deliberate.

---

## Desktop

On larger screens:

- Maintain a comfortable maximum content width.
- Use whitespace around the primary content.
- Avoid overly dense layouts.
- Use multi-column layouts only where they improve comprehension.
- Provide comfortable horizontal breathing room around primary content.
- Do not allow content to sit directly against the viewport or available page boundary simply because additional space is available.
- Use responsive container padding and/or a controlled maximum content width to create deliberate whitespace.

The goal is not to maximise the width of the application, but to create a comfortable reading and interaction area.

---

## Tablet

Layouts should naturally collapse where necessary.

Avoid forcing desktop layouts into narrow widths.

---

## Mobile

Mobile is a first-class experience.

Do not treat mobile as an afterthought.

On small screens:

- Stack content vertically.
- Keep controls comfortably tappable.
- Avoid horizontal scrolling wherever possible.
- Avoid dense tables where an alternative presentation is clearer.
- Preserve visual hierarchy.
- Keep primary actions obvious.

---

## Mobile spacing

On small screens, make efficient use of the available horizontal space.

Avoid excessive side margins that unnecessarily reduce the usable width of:

- Calendars
- Forms
- Data tables
- Primary content areas

Mobile spacing should provide sufficient breathing room without sacrificing useful content width.

--- 
 
# 9. Cards

Cards are useful for grouping related information.

Use them when they provide a meaningful grouping boundary.

Good examples:

- Summary statistics
- Tax calculation results
- Important information
- Related form sections

Avoid placing every individual element inside a card.

The application should not become a collection of nested boxes.

---

## Card appearance

Cards should generally use:

- Subtle background contrast
- Subtle border
- Minimal or restrained shadow
- Comfortable padding
- Consistent corner radius

Avoid:

- Heavy shadows
- Excessive gradients
- Highly rounded "pill" cards
- Decorative card backgrounds

---

# 10. Buttons

Buttons should have a clear hierarchy.

## Primary button

Use the WFHTracker primary orange for the most important action.

Examples:

- Add entry
- Save
- Continue
- Calculate
- Submit

There should generally be one visually dominant action within a section.

---

## Secondary button

Use a quieter visual treatment for secondary actions.

Examples:

- Cancel
- Back
- View details

---

## Destructive button

Use the semantic error/destructive styling.

Examples:

- Delete
- Remove

Destructive actions should never look identical to normal primary actions.

---

## Button principles

Buttons should:

- Have clear labels
- Be comfortably tappable
- Have visible hover states
- Have visible focus states
- Have disabled states
- Avoid unnecessary icons

Prefer:

> Add entry

over:

> + 

unless the context makes the icon-only action completely unambiguous.

---

# 11. Forms

Forms should feel straightforward and unintimidating.

Every input should have a clear purpose.

---

## Labels

Labels should be visible and descriptive.

Do not rely exclusively on placeholders as labels.

---

## Placeholder text

Placeholder text may provide examples but should not contain essential instructions.

---

## Help text

Use help text when the user may reasonably ask:

> "What does this mean?"

Keep help text concise.

---

## Validation

Validation should be:

- Clear
- Specific
- Close to the relevant field
- Written in plain language

Prefer:

> Enter the number of hours worked.

over:

> Invalid input.

---

## Focus

Focused inputs should have a clear visual indication.

Do not remove focus indicators.

---

# 12. Data Presentation

WFHTracker is fundamentally a data-entry and calculation application.

Data should therefore be easy to scan.

Important numbers should have strong visual hierarchy.

Examples include:

- Work-from-home days
- Hours worked
- Estimated deduction
- Current period totals

---

## Numbers

Large or important numbers may be visually emphasised.

However, do not make every number large.

Hierarchy matters.

---

## Tables

Tables are appropriate when the user needs to compare multiple records.

On mobile, consider alternative presentations when tables become difficult to read.

Never force a desktop table into an unusable mobile layout simply to preserve the table structure.

---

# 13. Dashboard / Summary Areas

Summary areas should answer the user's most important questions quickly.

For example:

> How much have I worked from home?

> What is my current total?

> What is my estimated deduction?

The most important information should be visible without requiring the user to interpret a complex chart.

---

# 14. Charts and Visualisations

Charts should explain data rather than decorate the interface.

Use charts only when they provide insight that is harder to obtain from numbers alone.

Avoid:

- 3D charts
- Excessive chart decoration
- Unnecessary legends
- Excessive colours
- Charts with little or no useful information

Charts should use the established WFHTracker visual palette.

---

# 15. Navigation

Navigation should be predictable.

Users should always understand:

- Where they are
- Where they can go
- How to return

Do not hide important navigation behind unnecessary interactions.

Navigation should remain clean on mobile.

---

# 16. Icons

Icons should support understanding.

They should not be used merely to make an interface look more sophisticated.

Use a consistent icon library/style throughout the application.

Do not mix unrelated icon styles.

---

## Icon principles

Prefer:

- Familiar symbols
- Consistent stroke/weight
- Consistent sizing
- Adequate spacing from text

Avoid:

- Decorative icon collections
- Oversized icons
- Emoji as UI icons
- Different icon styles in different components

---

# 17. Borders and Shadows

WFHTracker should use restrained depth.

Prefer subtle borders and very light shadows where required.

Avoid making every component appear elevated.

The interface should generally feel **flat with subtle hierarchy**, rather than a collection of floating panels.

---

# 18. Border Radius

Use a consistent corner-radius system.

The application should have soft corners, but not excessive rounding.

Avoid:

- Extremely rounded cards
- Pill-shaped containers unless they represent a status/badge
- Mixing many different radii

---

# 19. Loading States

Loading states should communicate that the application is working.

They should not dominate the screen.

Prefer:

- Simple progress indicators
- Skeletons where useful
- Clear loading text where ambiguity exists

Avoid elaborate animations.

---

# 20. Empty States

Empty states should be helpful rather than merely reporting that there is no data.

For example:

> No work-from-home entries yet.

followed by:

> Add your first entry to start tracking your WFH hours.

Where appropriate, provide a clear next action.

---

# 21. Error States

Errors should be calm and actionable.

Avoid technical language where the user does not need it.

Prefer:

> We couldn't save your entry. Please try again.

over:

> HTTP 500: Internal Server Error.

Technical details may be available to developers/logging without being exposed as the primary user message.

---

# 22. Notifications and Alerts

Notifications should be used sparingly.

They should communicate something meaningful.

Do not display notifications for every minor interaction.

Alerts should clearly communicate their semantic purpose:

- Information
- Success
- Warning
- Error

---

# 23. Authentication Screens

Authentication is part of the WFHTracker experience.

The sign-in experience should feel consistent with the main application.

Branding should be clear but restrained.

The WFHTracker logo should be displayed correctly and preserve its intended appearance.

Do not redesign the logo using CSS.

Do not substitute arbitrary icons or text for the logo.

---

# 24. Logo Usage

The WFHTracker logo is a brand asset.

Do not:

- Distort the logo
- Stretch the logo
- Change its proportions
- Apply arbitrary filters
- Add shadows
- Change its colours
- Place it against a background where it becomes difficult to read

The existing logo treatment, including its border/shape, is intentional.

The logo should work appropriately across light and dark environments.

---

# 25. Dark Mode

If dark mode is supported, it should be treated as a deliberate theme rather than simply inverting colours.

Maintain:

- Readable text
- Appropriate contrast
- Visible borders
- Clear input states
- Correct semantic colours
- Recognisable WFHTracker branding

Do not use pure black backgrounds unless there is an established reason.

---

# 26. Accessibility

Accessibility is part of the design, not an optional enhancement.

Ensure:

- Sufficient colour contrast
- Keyboard navigation
- Visible focus states
- Descriptive labels
- Meaningful button text
- Appropriate semantic HTML
- Accessible form validation
- Adequate touch targets
- Screen-reader-friendly controls

Do not rely on colour alone to communicate meaning.

For example, an error should not be communicated only by making a field red.

---

# 27. Responsive Behaviour

Every new component should be considered at:

- Desktop
- Tablet
- Mobile

before being considered complete.

A component that looks good on desktop but breaks on mobile is not finished.

Prefer responsive layouts over fixed pixel dimensions.

Use Tailwind responsive utilities and existing application breakpoints.

---

# 28. Animation

Animation should be subtle and purposeful.

Use animation only when it improves:

- Feedback
- Orientation
- Understanding

Avoid:

- Large entrance animations
- Excessive transitions
- Bouncing elements
- Continuous decorative animation

The application should feel calm.

---

# 29. Copy and Language

UI copy should be:

- Plain English
- Concise
- Friendly
- Direct
- Australian-English appropriate where relevant

Avoid unnecessarily technical language.

Prefer:

> Save entry

over:

> Persist record

Prefer:

> Delete entry

over:

> Execute deletion operation

---

# 30. Australian Context

WFHTracker is designed for Australian users.

Where tax-related terminology is used, use appropriate Australian terminology.

The application uses the **ATO fixed-rate method** for estimating work-from-home deductions.

Avoid presenting estimates as guaranteed tax outcomes.

Where appropriate, make it clear that calculations are estimates and users should verify their circumstances with the ATO or an appropriate tax professional.

---

# 31. Component Reuse

Before creating a new UI pattern, check whether an existing component already performs the required function.

Prefer:

> Reuse → Extend → Create new

rather than:

> Create new every time

The application should have a small number of consistent visual patterns.

---

# 32. Tailwind Usage

WFHTracker uses Tailwind CSS.

Prefer Tailwind utility classes and existing theme configuration.

Do not introduce arbitrary styling into individual components when an existing design token or utility can be used.

Avoid large blocks of component-specific CSS unless the behaviour genuinely requires it.

---

## Avoid arbitrary values

Prefer established spacing, colour, typography and radius utilities.

Avoid repeatedly introducing values such as:

```text
mt-[13px]
px-[27px]
rounded-[11px]
```

unless there is a genuine design requirement.

---

# 33. Blazor Components

WFHTracker is a Blazor application.

UI patterns that appear more than once should generally become reusable components.

Examples:

```text
Button
Card
FormField
Alert
SummaryCard
EmptyState
LoadingState
```

The exact component structure should follow the existing application architecture.

Do not create abstractions purely for the sake of abstraction.

---

# 34. Do / Don't

## Do

- Keep interfaces simple.
- Use consistent spacing.
- Reuse existing components.
- Use the WFHTracker orange intentionally.
- Maintain strong typography hierarchy.
- Design for mobile.
- Make important information obvious.
- Use whitespace.
- Provide clear feedback.
- Prefer familiar UI patterns.
- Keep visual noise low.

## Don't

- Add visual elements just because they look cool.
- Introduce random colours.
- Introduce new fonts.
- Create one-off component styles.
- Overuse cards.
- Overuse icons.
- Use excessive shadows.
- Make everything orange.
- Make everything a pill.
- Add unnecessary animation.
- Create overly complicated dashboards.
- Optimise for visual novelty over usability.

---

# 35. Copilot Instructions

When modifying the WFHTracker UI, Copilot should follow these rules.

### Rule 1 — Read this guide

This file is the authoritative visual design reference for WFHTracker.

### Rule 2 — Preserve existing design

Before changing a component, inspect the existing implementation and reuse established patterns.

Do not redesign unrelated areas while implementing a requested change.

### Rule 3 — Do not invent styles

Do not introduce:

- New colours
- New fonts
- New spacing systems
- New border-radius systems
- New button styles
- New icon styles

unless explicitly requested.

### Rule 4 — Prefer consistency

If two components perform similar functions, they should look and behave similarly.

### Rule 5 — Consider mobile

Every UI change must work on mobile as well as desktop.

### Rule 6 — Keep it simple

If there are multiple valid UI approaches, choose the simplest approach that provides a good user experience.

### Rule 7 — Respect the brand

WFHTracker should feel like a DC Digital product:

> Simple before clever.  
> Calm.  
> Clear.  
> Thoughtfully built.

### Rule 8 — Don't over-engineer

Do not introduce unnecessary libraries, abstractions or dependencies solely to implement a visual change.

Prefer the application's existing technology stack.

---

# 36. Visual North Star

When uncertain about a design decision, ask:

> **Does this make WFHTracker simpler, clearer and easier to use?**

If yes, it is probably aligned with the design system.

If it makes the interface:

- busier
- louder
- more complicated
- more decorative
- harder to understand

then reconsider it.

---

## Final Principle

WFHTracker should never try to impress the user with how much UI it contains.

It should impress them with **how easy it is to use**.

> **Simple Software. Quiet Confidence. Thoughtfully Built.**